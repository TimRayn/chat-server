using Chat.Data.Repositories.Interfaces;
using Chat.Repository;
using Chat.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<Message> Create(Message messsage)
        {
            await _context.Messages.AddAsync(messsage);
            await _context.SaveChangesAsync();
            return messsage;
        }

        public Task<List<Message>> GetAllByRoom(Guid roomId)
        {
            return _context.Messages.Where(x => x.RoomId == roomId).ToListAsync();
        }

        //public async Task<Message> Delete(Guid messageId)
        //{
        //    var message = _context.Messages.FirstOrDefault(x => x.Id == messageId);
        //    _context.Messages.Remove(message);
        //    await _context.SaveChangesAsync();
        //    return message;
        //}

        public async Task<List<Message>> Delete(Guid[] messageIds, bool forOwner)
        {
            if (forOwner) return await DeleteForOwner(messageIds);

            var messages = new List<Message>();
            await _context.Messages.ForEachAsync<Message>(message =>
            {
                if (messageIds.Contains(message.Id))messages.Add(message);
            });
            _context.Messages.RemoveRange(messages.ToArray());
            await _context.SaveChangesAsync();
            return messages;
        }

        private async Task<List<Message>> DeleteForOwner(Guid[] messageIds)
        {
            var messages = new List<Message>();
            foreach (var messageId in messageIds)
            {
                var message = await _context.Messages.FirstOrDefaultAsync(x => x.Id == messageId);
                message.IsDeletedForOwner = true;
                _context.Messages.Update(message);
                await _context.SaveChangesAsync();
                messages.Add(message);
            }
            return messages;
        }

        public async Task<Message> Update(Message newMessage)
        {
            var message = _context.Messages.FirstOrDefault(x => x.Id == newMessage.Id);
            message.Content = newMessage.Content;
            _context.Messages.Update(message);
            await _context.SaveChangesAsync();
            return message;
        }

        public Task<List<Message>> Get(Guid roomId, DateTime from, int count)
        {
            return _context.Messages
                .Where(x => x.RoomId == roomId && x.Date < from)
                .OrderByDescending(x => x.Date)
                .Take(count).ToListAsync();
        }
    } 
}
