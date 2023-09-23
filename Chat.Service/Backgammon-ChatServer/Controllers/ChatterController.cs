using Chat_DAL.Data;
using Chat_DAL.Repositories.interfaces;
using Chat_Models.Helpers;
using Chat_Models.Models;
using Chat_Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Backgammon_ChatServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ChatterController : ControllerBase
    {
        readonly IChatterRepository _chatterRepository;
        readonly IChatService _chatService;
        public ChatterController(IChatterRepository chatterRepository, IChatService chatService)
        {
            _chatterRepository = chatterRepository;
            _chatService = chatService;
        }

        

    }
}
