﻿using Chat_Models.Helpers;
using Chat_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_DAL.Repositories.interfaces
{
    public interface IMessageRepository
    {
        Task<Message> CreateMessageAsync(Guid senderId, Guid RecipientId, string newMessage);
        Task SetMessageReceivedAsync(Guid messageId);
        Task<IEnumerable<Message>> UserMessagesBetween(Guid user1,Guid user2);
    }
}
