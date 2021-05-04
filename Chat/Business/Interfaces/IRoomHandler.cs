using Chat.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Business.Interfaces
{
    public interface IRoomHandler
    {
        Task<RoomDTO> Create(CreateRoomDTO dto, CancellationToken cancel);
    }
}
