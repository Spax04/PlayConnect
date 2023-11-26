﻿using Chat.DAL.Repositories.Interfaces;
using Chat.Models.Helpers.ModelRequests;
using Chat.Models.Helpers.ModelResponses;
using Chat.Models.Models;
using Chat.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;
using System.IdentityModel.Tokens.Jwt;

namespace Chat.API.Hubs
{
    //[Authorize]
    public class ChatHub : Hub
    {
        private IConnectionService _chatService;
        private IMessageRepository _messageRepository;
        private IConnectionRepository _connectionRepository;
        public ChatHub(IConnectionService chatService, IMessageRepository messageRepository, IConnectionRepository connectionRepository)
        {
            _chatService = chatService;
            _messageRepository = messageRepository;
            _connectionRepository = connectionRepository;
        }


        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();

            var token = Context.GetHttpContext()?.Request.Query["access_token"];

            var tokenCheck = new JwtSecurityToken(token);
            string id = tokenCheck.Claims.First(x => x.Type == "userId").Value;
            string name = tokenCheck.Claims.First(x => x.Type == "name").Value;
            Guid chaterId = Guid.Parse(id);

            var chatter = await _chatService.GetOrAddChatterAsync(chaterId, name);


            var isFirstConnect = await _chatService.ConnectChatterAsync((Guid)chatter.Id, Context.ConnectionId);

            await Clients.Others.SendAsync("ChatterConnected", chatter.Id.ToString());


        }


        public override async Task OnDisconnectedAsync(Exception? exception)
        {

            await base.OnDisconnectedAsync(exception);
            var token = Context.GetHttpContext()?.Request.Query["access_token"].ToString();

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

        public async Task SendMessage(MessageRequest request)
        {
            if (!Guid.TryParse(request.SenderId, out var senderId)) return;
            if (!Guid.TryParse(request.RecipientId, out var recipientId)) return;

            Connection connection = await _connectionRepository.GetConnectionByUserIdAsync(recipientId);
            Message message;
            try
            {
                message = await _messageRepository.CreateMessageAsync(senderId, recipientId, request.NewMessage);
            }
            catch
            {
                return;
            }

            await Clients.Caller.SendAsync("ReceiveMessage", message);
            if (connection == null) return;
            await Clients.Client(connection.ConnectionId).SendAsync("ReceiveMessage", message);
        }

        public async Task MessageReceived(MessageReceivedRequest request)
        {
            if (!Guid.TryParse(request.MessageId, out var messageIdGuid)) return;
            if (!Guid.TryParse(request.SenderId, out var senderIdGuid)) return;

            Connection connection = await _connectionRepository.GetConnectionByUserIdAsync(senderIdGuid);

            try
            {
                await _messageRepository.SetMessageReceivedAsync(messageIdGuid);
            }
            catch
            {
                if (connection != null)
                {

                    await Clients.Client(connection.ConnectionId).SendAsync("OnMessageReceived",
                        new MessageReceivedResponse() 
                        { 
                            ChatterId = request.ReceiverId,
                            MessageId = request.MessageId,
                            Status = false
                        }
                    );
                    await Clients.Caller.SendAsync("OnMessageReceived",
                       new MessageReceivedResponse()
                       {
                           ChatterId = request.SenderId,
                           MessageId = request.MessageId,
                           Status = false
                       }
                   );
                }
                return;
            }

            if (connection != null)
            {

                await Clients.Client(connection.ConnectionId).SendAsync("OnMessageReceived",
                    new MessageReceivedResponse() 
                    {
                        ChatterId = request.ReceiverId,
                        MessageId = request.MessageId,
                        Status = true 
                    }
                );
                 await Clients.Caller.SendAsync("OnMessageReceived",
                       new MessageReceivedResponse()
                       {
                           ChatterId = request.SenderId,
                           MessageId = request.MessageId,
                           Status = true
                       }
                   );
            }
        }

        public async Task GetFriends(string userid)
        {
            if (!Guid.TryParse(userid, out var chatterId)) return;

            Connection connection = await _connectionRepository.GetConnectionByUserIdAsync(chatterId);

            if (connection == null) return;

            await Clients.Client(connection.ConnectionId).SendAsync("onGetFriends");
        }
    }
}