using Chat.Repository.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByNickName(string nickname, CancellationToken cancel);
        Task<User> Create(User user, CancellationToken cancel);
        Task<User> Get(Guid id, CancellationToken cancel);
    }
}
