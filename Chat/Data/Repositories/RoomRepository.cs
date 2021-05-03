using Chat.Data.Repositories.Interfaces;
using Chat.Repository;
using Chat.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<Room> Create(Room model)
        {
            _context.AttachRange(model.Users);
            await _context.Rooms.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public Task<Room> Get(Guid id)
        {
            return _context.Rooms.Include(x => x.Users).SingleAsync(x => x.RoomId == id);
        }
    }
}
