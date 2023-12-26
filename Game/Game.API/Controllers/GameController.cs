using Game.DAL.Interfaces;
using Game.Models.Dto.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
