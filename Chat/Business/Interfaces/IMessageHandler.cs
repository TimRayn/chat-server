using Chat.Contracts;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Business.Interfaces
{
    public interface IMessageHandler
    {
        Task<MessageDTO> Create(CreateMessageDTO dto, CancellationToken cancel);
        Task<List<MessageDTO>> GetAllByRoom(Guid roomId, CancellationToken cancel);
        Task Delete(Guid[] messages, bool forOwner, CancellationToken cancel);
        Task Update(UpdateMessageDTO message, CancellationToken cancel);
        Task<List<MessageDTO>> Get(Guid roomId, DateTime from, int count, CancellationToken cancel);
    }
}
