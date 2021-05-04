using Chat.Repository.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Data.Repositories.Interfaces
{
    public interface IRoomRepository
    {
        Task<Room> Create(Room model, CancellationToken cancel);
        Task<Room> Get(Guid id, CancellationToken cancel);
    }
}
