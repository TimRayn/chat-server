using Chat.Business.Interfaces;
using Chat.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Controllers
{
    [Route("api/[controller]/[action]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageHandler _handler;

        public MessageController(IMessageHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMessageDTO dto)
        {
            var message = await _handler.Create(dto);
            return Ok(message);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllByRoom([BindRequired] Guid roomId)
        {
            var message = await _handler.GetAllByRoom(roomId);
            return Ok(message);
        }

        public async Task<IActionResult> Get([BindRequired] Guid roomId, DateTime from, int count)
        {
            return Ok(await _handler.Get(roomId, from, count));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] Guid[] messageIds, [BindRequired] bool forOwner)
        {
            var messages = await _handler.Delete(messageIds, forOwner);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateMessageDTO dto)
        {
            var message = await _handler.Update(dto);
            return Ok(message);
        }

    }
}
