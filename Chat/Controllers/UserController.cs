using Chat.Business.Interfaces;
using Chat.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Chat.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUserHandler _handler;

        public UserController(IUserHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
        {
            var user = await _handler.Login(dto);
            return Ok(user);
        }
    }
}
