using Chat.Business.Interfaces;
using Chat.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Chat.Controllers
{
    [Route("api/[controller]/[action]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomHandler _handler;

        public RoomController(IRoomHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRoomDTO dto)
        {
            var message = await _handler.Create(dto, HttpContext.RequestAborted);
            return Ok(message);
        }
    }
}
