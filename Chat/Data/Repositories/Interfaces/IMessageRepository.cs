using Chat.Repository.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chat.Data.Repositories.Interfaces
{
    public interface IMessageRepository
    {
        Task<Message> Create(Message messsage);
        Task<List<Message>> GetAllByRoom(Guid roomId);
        //Task<Message> Delete(Guid messageId);
        Task<List<Message>> Delete(Guid[] messages, bool forOwner);
        Task<Message> Update(Message message);
        Task<List<Message>> Get(Guid roomId, DateTime from, int count);
    }
}
