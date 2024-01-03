using Game.DAL.Interfaces;
using Game.Models.Dto.Requests;
using Game.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Game.API.Controllers
{
    [Route("api/game")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private IGameRepository _gameRepository;
        public GameController( IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        [HttpPut]
        public async Task<ActionResult> UpdateSessionTime(UpdateSessionTimeRequest updateRequest)
        {

            if (updateRequest.SessionId == null || String.IsNullOrEmpty(updateRequest.SessionId))
            {
                return BadRequest("Session Id id is null");

            }

            if (!Guid.TryParse(updateRequest.SessionId, out var sessionId))
            {
                return BadRequest("Session id is not correct");
            }

            if (await _gameRepository.UpdateSessionTimeAsync(sessionId, updateRequest.isStarted))
                return Ok();
            else
                return BadRequest("Something went wrong");
        }

        [HttpPost("game-type/")]
        public async Task<IActionResult> CreateGameType(string gameName, IFormFile file)
        {
            byte[] img;
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                img = memoryStream.ToArray();
            }

            await _gameRepository.CreateGameTypeAsync(new GameTypeCreateRequest { Name = gameName,Image = img});

            return Ok();
        }

        [HttpGet("game-type/")]
        public async Task<IActionResult> GatGameTypes()
        {
            var gameTypes = await _gameRepository.GetGameTypesAsync();
            
            return gameTypes == null? BadRequest() : Ok(gameTypes);

        }
    }
}
