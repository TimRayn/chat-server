using Chat.Repository.Models;
using System;
using System.Threading.Tasks;

namespace Chat.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByNickName(string nickname);
        Task<User> Create(User user);
        Task<User> Get(Guid id);
    }
}
