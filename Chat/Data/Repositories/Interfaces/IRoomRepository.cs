using Chat.Repository.Models;
using System;
using System.Threading.Tasks;

namespace Chat.Data.Repositories.Interfaces
{
    public interface IRoomRepository
    {
        Task<Room> Create(Room model);
        Task<Room> Get(Guid id);
    }
}
