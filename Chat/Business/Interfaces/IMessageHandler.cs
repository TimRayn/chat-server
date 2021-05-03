using Chat.Contracts;
using Chat.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Business.Interfaces
{
    public interface IMessageHandler
    {
        Task<Message> Create(CreateMessageDTO dto);
        Task<List<Message>> GetAllByRoom(Guid roomId);
        //Task<Message> Delete(Guid messageId);
        Task<List<Message>> Delete(Guid[] messages, bool forOwner);
        Task<Message> Update(UpdateMessageDTO message);
        Task<List<Message>> Get(Guid roomId, DateTime from, int count);

    }
}
