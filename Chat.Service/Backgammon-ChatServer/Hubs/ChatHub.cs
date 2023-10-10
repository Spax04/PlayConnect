using Chat_DAL.Repositories;
using Chat_Models.Models;
using Chat_Services;
using Chat_Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.IdentityModel.Tokens.Jwt;

namespace Backgammon_ChatServer.Hubs
{
    //[Authorize]
    public class ChatHub : Hub
    {
        private IChatService _chatService;
        private IMessageService _messageService;
        public ChatHub(IChatService chatService, IMessageService messageService)
        {
            _chatService = chatService;
            _messageService = messageService;
        }


        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();

            if (Guid.TryParse(Context.UserIdentifier, out var chaterId))
            {

            }else
                return;

            await Clients.All.SendAsync("ReceiveUpdate", "HELLO");

            /*var tokenCheck = new JwtSecurityToken(token);
            string id = tokenCheck.Claims.First(x => x.Type == "userId").Value;
            string name = tokenCheck.Claims.First(x => x.Type == "name").Value;
            Guid chaterId = Guid.Parse(id);

            var chatter = await _chatService.GetOrAddChatterAsync(chaterId, name);


            // create connection with current chatter and toggle connection to true -- returns true if conection was created
            var isFirstConnect = await _chatService.ConnectChatterAsync((Guid)chatter.Id, Context.ConnectionId);

            var chattersWithoutCaller = await _chatService.GetChattersAsync(chaterId);

            
                var chatterIds = chattersWithoutCaller.Select(c => c.Id.ToString()).ToList();

                // Who is online - automatacly gets new user that connected
                await Clients.Others.SendAsync("ChatterConnected", chatter);
           
            // Caller gets list of users online
            await Clients.Caller.SendAsync("SetChatters", chattersWithoutCaller);*/
        }


        public override async Task OnDisconnectedAsync(Exception exception)
        {

            await base.OnDisconnectedAsync(exception);
            string token = Context.GetHttpContext().Request.Query["token"].ToString();

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
                await Clients.Others.SendAsync("ChatterDisconnect", chatter);
            }

        }

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
