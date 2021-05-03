using System;
using System.Collections.Generic;

namespace Chat.Repository.Models
{
    public class Room
    {
        public Guid RoomId { get; set; }
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
