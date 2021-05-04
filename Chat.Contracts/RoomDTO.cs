using System;
using System.Collections.Generic;

namespace Chat.Contracts
{
    public class RoomDTO
    {
        public Guid RoomId { get; set; }
        public string Name { get; set; }

        public List<UserDTO> Users { get; set; }
    }
}
