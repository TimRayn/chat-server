using Chat.Data.Repositories.Interfaces;
using Chat.Repository;
using Chat.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Data.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ChatDbContext _context;

        public MessageRepository(ChatDbContext context)
        {
            _context = context;
        }
        public async Task<Message> Create(Message messsage, CancellationToken cancel)
        {
            await _context.Messages.AddAsync(messsage, cancel);
            await _context.SaveChangesAsync(cancel);
            return messsage;
        }

        public Task<List<Message>> GetAllByRoom(Guid roomId, CancellationToken cancel)
        {
            return _context.Messages.Where(x => x.RoomId == roomId).ToListAsync(cancel);
        }

        public async Task<List<Message>> Delete(Guid[] messageIds, bool forOwner, CancellationToken cancel)
        {
            if (forOwner) return await DeleteForOwner(messageIds, cancel);

            var messages = await _context.Messages.Where(message => messageIds.Contains(message.Id))
                .ToListAsync(cancel);
            _context.Messages.RemoveRange(messages);
            await _context.SaveChangesAsync(cancel);
            return messages;
        }

        private async Task<List<Message>> DeleteForOwner(Guid[] messageIds, CancellationToken cancel)
        {
            var messages = new List<Message>();
            foreach (var messageId in messageIds)
            {
                var message = await _context.Messages.FirstOrDefaultAsync(x => x.Id == messageId, cancel);
                message.IsDeletedForOwner = true;
                _context.Messages.Update(message);
                await _context.SaveChangesAsync(cancel);
                messages.Add(message);
            }
            return messages;
        }

        public async Task<Message> Update(Message newMessage, CancellationToken cancel)
        {
            var message = await _context.Messages.FirstOrDefaultAsync(x => x.Id == newMessage.Id, cancel);
            message.Content = newMessage.Content;
            _context.Messages.Update(message);
            await _context.SaveChangesAsync(cancel);
            return message;
        }

        public Task<List<Message>> Get(Guid roomId, DateTime from, int count, CancellationToken cancel)
        {
            return _context.Messages
                .Where(x => x.RoomId == roomId && x.Date < from)
                .OrderByDescending(x => x.Date)
                .Take(count).ToListAsync(cancel);
        }
    } 
}
