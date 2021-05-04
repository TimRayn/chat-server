using Chat.Contracts;
using Chat.Repository.Models;
using System;

namespace Chat.Mappers
{
    public static class MessageMappers
    {
        public static Message ToEntity(this CreateMessageDTO dto)
        {
            if (dto == null) return null;

            return new Message
            {
                Id = Guid.NewGuid(),
                Content = dto.Content,
                Date = DateTime.Now,
                RoomId = dto.RoomId,
                UserId = dto.UserId,
                RepliedMessageContent = dto.RepliedMessageContent
            };
        }
        
        public static MessageDTO ToDTO(this Message entity)
        {
            return new MessageDTO
            {
                Content = entity.Content,
                Date = entity.Date,
                Id = entity.Id,
                IsDeletedForOwner = entity.IsDeletedForOwner,
                RepliedMessageContent = entity.RepliedMessageContent,
                RoomId = entity.RoomId,
                UserId = entity.UserId,
            };
        }

        public static Message ToEntity(this UpdateMessageDTO dto)
        {
            return new Message
            {
                Id = dto.Id,
                Content = dto.Content
            };
        }
    }
}
