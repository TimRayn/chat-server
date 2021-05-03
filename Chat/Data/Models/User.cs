using System;
using System.Collections.Generic;

namespace Chat.Repository.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string NickName { get; set; }

        public ICollection<Room> Rooms { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
