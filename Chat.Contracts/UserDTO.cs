using System;
using System.Collections.Generic;

namespace Chat.Contracts
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string NickName { get; set; }

        public List<RoomDTO> Rooms { get; set; }
    }
}
