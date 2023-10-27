﻿using Chat_DAL.Repositories.interfaces;
using Chat_Models.Helpers;
using Chat_Models.Models;
using Chat_Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Backgammon_ChatServer.Controllers
{
    [Route("api/chatter")]
    [ApiController]
    
    public class ChatterController : ControllerBase
    {
        readonly IChatterRepository _chatterRepository;
        readonly IConnectionService _chatService;
        public ChatterController(IChatterRepository chatterRepository, IConnectionService chatService)
        {
            _chatterRepository = chatterRepository;
            _chatService = chatService;
        }

        [HttpGet]
        public async Task<ActionResult> GetChattersAreOnline(string chatterId)
        {

            if(chatterId == null || chatterId.IsNullOrEmpty())
            {
                return BadRequest("Chatter id is null");

            }

            if(!Guid.TryParse(chatterId, out var chatterId2))
            {
                return BadRequest("Chatter id is not correct");
            }

            IEnumerable<Chatter> chattersOnline = await _chatterRepository.GetChattersAreOnlineAsync(chatterId2);

            return Ok(chattersOnline);
        }

        [HttpGet("isonline/{chatterId}")]
        public async Task<ActionResult> IsChatterOnline(string chatterId)
        {

            if (chatterId == null || chatterId.IsNullOrEmpty())
            {
                return BadRequest("Chatter id is null");

            }

            if (!Guid.TryParse(chatterId, out var chatterId2))
            {
                return BadRequest("Chatter id is not correct");
            }

            Response chatterOnline = await _chatterRepository.IsChatterConnectedAsync(chatterId2);

            return Ok(chatterOnline);
        }


    }
}
