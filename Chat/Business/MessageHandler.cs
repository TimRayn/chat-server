using Chat.Business.Interfaces;
using Chat.Contracts;
using Chat.Data.Repositories.Interfaces;
using Chat.Hubs;
using Chat.Repository.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
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

        public async Task<Message> Create(CreateMessageDTO dto)
        {
            var message = await _repository.Create(new Message
            {
                Id = Guid.NewGuid(),
                Content = dto.Content,
                Date = DateTime.Now,
                RoomId = dto.RoomId,
                UserId = dto.UserId,
                RepliedMessageContent = dto.RepliedMessageContent
            });

            await _hubContext.Clients.Group(dto.RoomId.ToString()).SendAsync("MessageSent", message);

            return message;
        }

        public Task<List<Message>> GetAllByRoom(Guid roomId)
        {
            return _repository.GetAllByRoom(roomId);
        }

        public async Task<List<Message>> Delete(Guid[] messages, bool forOwner)
        {
            var deletedMessages = await _repository.Delete(messages, forOwner);
            await _hubContext.Clients.Group(deletedMessages[0].RoomId.ToString()).SendAsync("MessagesDeleted", deletedMessages);
            return deletedMessages;
        }

        public async Task<Message> Update(UpdateMessageDTO dto)
        {
            var newMessage = await _repository.Update(new Message
            {
                Id = dto.Id,
                Content = dto.Content,
                Date = dto.Date,
                RoomId = dto.RoomId,
                UserId = dto.UserId
            });
            await _hubContext.Clients.Group(dto.RoomId.ToString()).SendAsync("MessageUpdated", newMessage);
            return newMessage;
        }

        public Task<List<Message>> Get(Guid roomId, DateTime from, int count)
        {
            return _repository.Get(roomId, from, count);
        }
    }
}
