using System;
using System.Collections.Generic;

namespace Chat.Contracts.SocketMessages
{
    public class RoomCreatedDTO
    {
        public Guid RoomId { get; set; }
        public string Name { get; set; }

        public List<UserDTO> Users { get; set; }
    }
}
