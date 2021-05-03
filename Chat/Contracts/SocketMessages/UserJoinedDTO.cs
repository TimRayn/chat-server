using Chat.Repository.Models;
using System;

namespace Chat.Contracts.SocketMessages
{
    public class UserJoinedDTO
    {
        public User User { get; set; }
        public Guid RoomId { get; set; }
    }
}
