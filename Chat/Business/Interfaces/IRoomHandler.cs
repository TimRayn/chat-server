using Chat.Contracts;
using Chat.Repository.Models;
using System.Threading.Tasks;

namespace Chat.Business.Interfaces
{
    public interface IRoomHandler
    {
        Task<Room> Create(CreateRoomDTO dto);
    }
}
