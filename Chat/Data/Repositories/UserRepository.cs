using Chat.Data.Repositories.Interfaces;
using Chat.Repository;
using Chat.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ChatDbContext _context;

        public UserRepository(ChatDbContext context)
        {
            _context = context;
        }

        public async Task<User> Create(User user, CancellationToken cancel)
        {
            _context.AttachRange(user.Rooms);
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync(cancel);
            return user;
        }

        public Task<User> GetByNickName(string nickname, CancellationToken cancel)
        {
            return _context.Users.Include(x => x.Rooms).ThenInclude(x => x.Users)
                .FirstOrDefaultAsync(x => x.NickName == nickname, cancel);
        }

        public Task<User> Get(Guid id, CancellationToken cancel)
        {
            return _context.Users.FirstOrDefaultAsync(x => x.Id == id, cancel);
        }
    }
}
