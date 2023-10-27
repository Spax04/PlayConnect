using Chat_DAL.Repositories.interfaces;
using Chat_Models.Models;
using Chat_Services.Interfaces;
using Microsoft.AspNetCore.SignalR;
using System.IdentityModel.Tokens.Jwt;

namespace Backgammon_ChatServer.Hubs
{
    //[Authorize]
    public class ChatHub : Hub
    {
        private IConnectionService _chatService;
        private IMessageService _messageService;
        private IConnectionRepository _connectionRepository;
        public ChatHub(IConnectionService chatService, IMessageService messageService, IConnectionRepository connectionRepository)
        {
            _chatService = chatService;
            _messageService = messageService;
            _connectionRepository = connectionRepository;
        }


        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();

            var token = Context.GetHttpContext().Request.Query["access_token"];



            await Clients.All.SendAsync("ReceiveMessage", "HELLO");

            var tokenCheck = new JwtSecurityToken(token);
            string id = tokenCheck.Claims.First(x => x.Type == "userId").Value;
            string name = tokenCheck.Claims.First(x => x.Type == "name").Value;
            Guid chaterId = Guid.Parse(id);

            var chatter = await _chatService.GetOrAddChatterAsync(chaterId, name);


            var isFirstConnect = await _chatService.ConnectChatterAsync((Guid)chatter.Id, Context.ConnectionId);

            await Clients.Others.SendAsync("ChatterConnected", chatter.Id.ToString());


        }


        public override async Task OnDisconnectedAsync(Exception exception)
        {

            await base.OnDisconnectedAsync(exception);
            var token = Context.GetHttpContext().Request.Query["access_token"].ToString();

            var tokenCheck = new JwtSecurityToken(token);
            string id = tokenCheck.Claims.First(x => x.Type == "userId").Value;
            Guid chatterId = Guid.Parse(id);

            var chatter = await _chatService.GetChatterAsync(chatterId);

            if (chatter == null)
                return;

            if (await _chatService.DisconnectChatterAsync(chatter.Id, Context.ConnectionId))
            {
                var lastSeen = await _chatService.GetLastSeenAsync(chatterId);
                chatter.LastSeen = lastSeen;
                await Clients.Others.SendAsync("ChatterDisconnect", chatter.Id.ToString());
            }

        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task GetFriends(string userid)
        {
            if (!Guid.TryParse(userid, out var chatterId)) return;

            Connection connection = await _connectionRepository.GetConnectionByUserIdAsync(chatterId);

            if(connection == null) return;

            await Clients.Client(connection.ConnectionId).SendAsync("onGetFriends");
        }
    }
}
