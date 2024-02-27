using Game.DAL.Interfaces;
using Game.Models.Dto.Requests;
using Game.Models.Dto.Responses;
using Game.Models.Models;
using Microsoft.AspNetCore.SignalR;
using System.IdentityModel.Tokens.Jwt;

namespace Game.API.Hubs
{
    public class GameHub : Hub
    {
        private IPlayerRepository _playerRepository;
        private IConnectionService _connectionService;
        private IConnectionRepository _connectionRepository;
        private IGameRepository _gameRepository;
        private IGameService _gameService;
        private IPlayerService _playerService;
        public GameHub(IPlayerRepository playerRepository, IConnectionService connectionService, IConnectionRepository connectionRepository, IGameRepository gameRepository, IGameService gameService, IPlayerService playerService)
        {
            _playerRepository = playerRepository;
            _connectionService = connectionService;
            _connectionRepository = connectionRepository;
            _gameRepository = gameRepository;
            _gameService = gameService;
            _playerService = playerService;
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();

            var token = Context.GetHttpContext()?.Request.Query["access_token"];

            var tokenCheck = new JwtSecurityToken(token);
            string id = tokenCheck.Claims.First(x => x.Type == "userId").Value;
            Guid playerId = Guid.Parse(id);

            var player = await _playerRepository.GetOrCreatePlayerAsync(playerId);

            var isFirstConnect = await _connectionService.ConnectPlayerAsync((Guid)player.Id, Context.ConnectionId);

            GameSession gameSession = await _gameRepository.GetCurrentGameSessionByPlayerIdAsync(player.Id);

            if (gameSession != null)
            {

                GamePlayerStat stat = await _gameRepository.GetGamePlayerStatByPlayerAndGameIdAsync(player.Id, gameSession.GameTypeId);
                await Groups.AddToGroupAsync(Context.ConnectionId, gameSession.Id.ToString());

                await Clients.Group(gameSession.Id.ToString()).SendAsync("ReconnectToGame", new ReconnectedResponse
                {
                    GameSessionId = gameSession.Id,
                    GameTypeId = gameSession.GameTypeId,
                    GameLevel = stat.Level,
                    GamePoints = stat.Points,
                    PlayerId = player.Id
                });
            }

            await Clients.Others.SendAsync("PlayerConnected", player.Id.ToString());

        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {

            await base.OnDisconnectedAsync(exception);
            var token = Context.GetHttpContext()?.Request.Query["access_token"].ToString();

            var tokenCheck = new JwtSecurityToken(token);
            string id = tokenCheck.Claims.First(x => x.Type == "userId").Value;
            Guid playerId = Guid.Parse(id);

            var player = await _playerRepository.GetPlayerAsync(playerId);

            if (player == null)
                return;
            GameSession gameSession = await _gameRepository.GetCurrentGameSessionByPlayerIdAsync(player.Id);

            if (gameSession != null)
            {

                GamePlayerStat stat = await _gameRepository.GetGamePlayerStatByPlayerAndGameIdAsync(player.Id, gameSession.GameTypeId);
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, gameSession.Id.ToString());

                await Clients.Group(gameSession.Id.ToString()).SendAsync("OpponentDisconnected", new OpponentDisconectResponse
                {
                    OpponentId = player.Id
                });
            }

            if (await _connectionService.DisconnectPlayerAsync(player.Id, Context.ConnectionId))
            {
                await Clients.Others.SendAsync("PlayerDisconnected", player.Id.ToString());
            }

        }

        public async Task InviteFriendToGame(InviteRequest request)
        {
            if (!Guid.TryParse(request.GuestId, out var friendId)) return;

            Connection connection = await _connectionRepository.GetConnectionByUserIdAsync(friendId);


            if (connection == null) return;
            await Clients.Client(connection.ConnectionId).SendAsync("GetInviteToGame", request);
        }


        public async Task InviteResponseByGuest(InviteResponse response)
        {
            if (!Guid.TryParse(response.HostId, out var hostId)) return;
            if (!Guid.TryParse(response.GuestId, out var guestId)) return;
            if (!Guid.TryParse(response.GameTypeId, out var gameTypeId)) return;

            Connection hostConnection = await _connectionRepository.GetConnectionByUserIdAsync(hostId);

            if (hostConnection == null) return;

            if (response.IsAccepted)
            {
                GameSession newGameSession = await _gameRepository.CreateGameSessionAsync(hostId, guestId, gameTypeId);
                await Groups.AddToGroupAsync(Context.ConnectionId, newGameSession.Id.ToString());
                await Groups.AddToGroupAsync(hostConnection.ConnectionId, newGameSession.Id.ToString());

                bool firstTurn = _gameService.IsStartsFirst();
                GamePlayerStat hostStats = await _gameRepository.GetGamePlayerStatByPlayerAndGameIdAsync(hostId, gameTypeId);
                GamePlayerStat guestStats = await _gameRepository.GetGamePlayerStatByPlayerAndGameIdAsync(guestId, gameTypeId);

                if (hostStats != null)
                {

                    await Clients.Group(newGameSession.Id.ToString()).SendAsync("JoinedToGame", new JoinToGameResponse
                    {
                        GameSessionId = newGameSession.Id.ToString(),
                        PlayerId = response.HostId,
                        GameTypeId = response.GameTypeId,
                        IsMyTurn = firstTurn,
                        IsPlayer = true,
                        GameLevel = hostStats.Level,
                        GamePoints = hostStats.Points,
                    });
                }
                else
                {
                    await _gameRepository.CreateGamePlayerStats(gameTypeId, hostId);
                    await Clients.Group(newGameSession.Id.ToString()).SendAsync("JoinedToGame", new JoinToGameResponse
                    {
                        GameSessionId = newGameSession.Id.ToString(),
                        PlayerId = response.HostId,
                        GameTypeId = response.GameTypeId,
                        IsMyTurn = firstTurn,
                        IsPlayer = true,
                        GameLevel = 1,
                        GamePoints = 0,
                    });
                }


                if (guestStats != null)
                {

                    await Clients.Group(newGameSession.Id.ToString()).SendAsync("JoinedToGame", new JoinToGameResponse
                    {
                        GameSessionId = newGameSession.Id.ToString(),
                        PlayerId = response.GuestId,
                        GameTypeId = response.GameTypeId,
                        IsMyTurn = !firstTurn,
                        IsPlayer = true,
                        GameLevel = guestStats.Level,
                        GamePoints = guestStats.Points,
                    });
                }
                else
                {

                    await _gameRepository.CreateGamePlayerStats(gameTypeId, guestId);

                    await Clients.Group(newGameSession.Id.ToString()).SendAsync("JoinedToGame", new JoinToGameResponse
                    {
                        GameSessionId = newGameSession.Id.ToString(),
                        PlayerId = response.GuestId,
                        GameTypeId = response.GameTypeId,
                        IsMyTurn = !firstTurn,
                        IsPlayer = true,
                        GameLevel = 1,
                        GamePoints = 0,
                    });
                }
            }
            else
            {

                await Clients.Client(hostConnection.ConnectionId).SendAsync("GetRefusalResponse");
            }

        }


        public async Task JoinToGameSession(ReadyToGameRequest readyToGameResponse)
        {
            if (!Guid.TryParse(readyToGameResponse.PlayerId, out var playerId)) { return; }
            string status = readyToGameResponse.IsPlayer ? "Player" : "Guest";
            await _playerService.UpdateInGamePlayerStatus(playerId, true);

            await Clients.Group(readyToGameResponse.GameSessionId).SendAsync(
                "ReadyToGame",
                new ReadyToGameResponse
                {
                    PlayerId = readyToGameResponse.PlayerId,
                    PlayerName = readyToGameResponse.PlayerName,
                    IsPlayer = readyToGameResponse.IsPlayer,
                    Message = $"{readyToGameResponse.PlayerName} has joind the game as {status}"
                });
        }


        public async Task MakeGameMove(GameMoveRequest moveRequest)
        {
            if (!Guid.TryParse(moveRequest.GameTypeId, out var gameTypeId))
                return;

            Move move = await _gameService.ConvertJsonToGameMoveAsync(gameTypeId, moveRequest.GameMove);

            if (!await _gameRepository.SaveGameMoveAsync(move))
            {
                throw new Exception();
            }

            await Clients.Group(moveRequest.GameSessionId).SendAsync("NewGameMove", moveRequest);

        }

        public async Task GameOver(GameOverRequest gameOverRequest)
        {
            if (!Guid.TryParse(gameOverRequest.GameSessionId, out var gameSessionId))
                return;
            if (!Guid.TryParse(gameOverRequest.GameTypeId, out var gameTypeId))
                return;
            if (!Guid.TryParse(gameOverRequest.PlayerId, out var playerId))
                return;
            if (!Guid.TryParse(gameOverRequest.OpponentId, out var opponentId))
                return;
            GamePlayerStat gamePlayerStats;

            await _gameRepository.UpdateGamePlayerStatsAsync(playerId, gameTypeId, gameOverRequest.NewLevel, gameOverRequest.NewPoints);
            gamePlayerStats = await _gameRepository.GetGamePlayerStatByPlayerAndGameIdAsync(playerId, gameTypeId);
            await _gameRepository.CreateGameResultAsync(gameSessionId, gamePlayerStats.Id, gameTypeId, playerId, opponentId, gameOverRequest.IsWinner, gameOverRequest.OpponentName, gameOverRequest.PlayerName
                );
            await _playerService.UpdateInGamePlayerStatus(playerId, false);

            await _gameService.SetGameSessionFinished(gameSessionId);

            await Groups.RemoveFromGroupAsync(Context.ConnectionId, gameOverRequest.GameSessionId);
        }

        public async Task OpponentReconnect(OpponentReconnectResponse opponentReconnectResponse)
        {
            await Clients.Group(opponentReconnectResponse.GameSessionId).SendAsync(
               "ReconnectHandler", opponentReconnectResponse);

        }

        public async Task ReconnectComplited(OpponentReconnectRequest opponentReconnectRequest)
        {

            await Clients.Group(opponentReconnectRequest.GameSessionId).SendAsync(
               "OpponentReconected", opponentReconnectRequest);

        }
    }
}