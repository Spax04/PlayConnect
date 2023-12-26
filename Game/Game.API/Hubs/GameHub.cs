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
        public GameHub(IPlayerRepository playerRepository, IConnectionService connectionService, IConnectionRepository connectionRepository, IGameRepository gameRepository)
        {
            _playerRepository = playerRepository;
            _connectionService = connectionService;
            _connectionRepository = connectionRepository;
            _gameRepository = gameRepository;
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

            if (await _connectionService.DisconnectPlayerAsync(player.Id, Context.ConnectionId))
            {
                await Clients.Others.SendAsync("PlayerDisconnected", player.Id.ToString());
            }

        }

        public async Task InviteFriendToGame(InviteRequest request)
        {
            if (!Guid.TryParse(request.FriendId, out var friendId)) return;

            Connection connection = await _connectionRepository.GetConnectionByUserIdAsync(friendId);

            if (connection == null) return;
            await Clients.Client(connection.ConnectionId).SendAsync("GetInviteToGame");
        }


        public async Task InviteResponseByGuest(InviteResponse response)
        {
            if (!Guid.TryParse(response.FriendId, out var friendId)) return;

            Connection connection = await _connectionRepository.GetConnectionByUserIdAsync(friendId);

            if (connection == null) return;
            await Clients.Client(connection.ConnectionId).SendAsync("GetInviteResponse", response);
        }

        public async Task CreateGameSession(NewGameRequest newGameRequest)
        {
            if (!Guid.TryParse(newGameRequest.HostId, out var hostId)) return;
            if (!Guid.TryParse(newGameRequest.GuestId, out var guestId)) return;

            Connection connection = await _connectionRepository.GetConnectionByUserIdAsync(guestId);

            GameSession newGameSession = await _gameRepository.CreateGameSessionAsync(hostId, guestId);

            await Groups.AddToGroupAsync(Context.ConnectionId, newGameSession.Id.ToString());

            if (connection == null) return;
            await Clients.Client(connection.ConnectionId).SendAsync("GameIsReady", );
        }
    }
}