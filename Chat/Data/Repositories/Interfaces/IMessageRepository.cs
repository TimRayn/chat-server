using Chat.Repository.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Data.Repositories.Interfaces
{
    public interface IMessageRepository
    {
        Task<Message> Create(Message messsage, CancellationToken cancel);
        Task<List<Message>> GetAllByRoom(Guid roomId, CancellationToken cancel);
        Task<List<Message>> Delete(Guid[] messages, bool forOwner, CancellationToken cancel);
        Task<Message> Update(Message message, CancellationToken cancel);
        Task<List<Message>> Get(Guid roomId, DateTime from, int count, CancellationToken cancel);
    }
}
