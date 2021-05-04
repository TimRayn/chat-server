using Chat.Data.Repositories.Interfaces;
using Chat.Repository;
using Chat.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Chat.Data.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ChatDbContext _context;

        public RoomRepository(ChatDbContext context)
        {
            _context = context;
        }

        public async Task<Room> Create(Room model, CancellationToken cancel)
        {
            _context.AttachRange(model.Users);
            await _context.Rooms.AddAsync(model);
            await _context.SaveChangesAsync(cancel);
            return model;
        }

        public Task<Room> Get(Guid id, CancellationToken cancel)
        {
            return _context.Rooms.Include(x => x.Users).SingleAsync(x => x.RoomId == id, cancel);
        }
    }
}
