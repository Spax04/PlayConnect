using Game.DAL.Interfaces;
using Microsoft.AspNetCore.SignalR;
using System.IdentityModel.Tokens.Jwt;

namespace Game.API.Hubs
{
    public class GameHub : Hub
    {
        private IPlayerRepository _playerRepository;
        private IConnectionService _connectionService;
        public GameHub(IPlayerRepository playerRepository, IConnectionService connectionService)
        {
            _playerRepository = playerRepository;
            _connectionService = connectionService;
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

            if (await _chatService.DisconnectChatterAsync(player.Id, Context.ConnectionId))
            {
                var lastSeen = await _chatService.GetLastSeenAsync(playerId);
                player.LastSeen = lastSeen;
                await Clients.Others.SendAsync("ChatterDisconnect", player.Id.ToString());
            }

        }
    }
}
