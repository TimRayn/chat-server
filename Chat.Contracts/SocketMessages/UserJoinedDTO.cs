using System;

namespace Chat.Contracts.SocketMessages
{
    public class UserJoinedDTO
    {
        public UserDTO User { get; set; }
        public Guid RoomId { get; set; }
    }
}
