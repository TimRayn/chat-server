using Chat.Data;
using Chat.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Chat.Repository
{
    public class ChatDbContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }

        public ChatDbContext(DbContextOptions<ChatDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>().HasData(new Room
            {
                RoomId = StaticData.PublicRoomId,
                Name = "Public"
            }); // Initialize "Public" room
            modelBuilder.Entity<User>().HasData(new User 
            { 
                NickName = "Test", 
                Id = StaticData.TestUserId 
            });
        }
    }
}
