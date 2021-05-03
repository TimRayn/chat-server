using Chat.Contracts;
using Chat.Repository.Models;
using System.Threading.Tasks;

namespace Chat.Business.Interfaces
{
    public interface IUserHandler
    {
        Task<User> Login(LoginDTO dto);
    }
}
