using Chat.Repository.Models;
using Microsoft.EntityFrameworkCore;

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
                RoomId = new System.Guid("B7C83C21-09F2-46C2-9CB1-461AEA2565D4"),
                Name = "Public"
            }); // Initialize "Public" room
        }
    }
}
