using Chat.Business.Interfaces;
using Chat.Contracts;
using Chat.Data.Repositories.Interfaces;
using Chat.Hubs;
using Chat.Mappers;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Business
{
    public class MessageHandler : IMessageHandler
    {
        private readonly IMessageRepository _repository;
        private readonly IHubContext<MessageHub> _hubContext;

        public MessageHandler(IMessageRepository repository, IHubContext<MessageHub> hubContext)
        {
            _repository = repository;
            _hubContext = hubContext;
        }

        public async Task<MessageDTO> Create(CreateMessageDTO dto, CancellationToken cancel)
        {
            var message = await _repository.Create(dto.ToEntity(), cancel);
            await _hubContext.Clients.Group(dto.RoomId.ToString()).SendAsync("MessageSent", message);
            return message.ToDTO();
        }

        public async Task<List<MessageDTO>> GetAllByRoom(Guid roomId, CancellationToken cancel)
        {
            var messages = await _repository.GetAllByRoom(roomId, cancel);
            return messages.Select(x => x.ToDTO()).ToList();
        }

        public async Task Delete(Guid[] messages, bool forOwner, CancellationToken cancel)
        {
            var deletedMessages = await _repository.Delete(messages, forOwner, cancel);
            await _hubContext.Clients
                .Group(deletedMessages[0].RoomId.ToString())
                .SendAsync("MessagesDeleted", deletedMessages);
        }

        public async Task Update(UpdateMessageDTO dto, CancellationToken cancel)
        {
            var newMessage = await _repository.Update(dto.ToEntity(), cancel);
            await _hubContext.Clients.Group(newMessage.RoomId.ToString())
                .SendAsync("MessageUpdated", newMessage);
        }

        public async Task<List<MessageDTO>> Get(Guid roomId, DateTime from, int count, CancellationToken cancel)
        {
            var messages = await _repository.Get(roomId, from, count, cancel);
            return messages.Select(x => x.ToDTO()).ToList();
        }
    }
}
