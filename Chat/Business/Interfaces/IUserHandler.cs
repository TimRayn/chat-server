using Chat.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Business.Interfaces
{
    public interface IUserHandler
    {
        Task<UserDTO> Login(LoginDTO dto, CancellationToken cancel);
    }
}
