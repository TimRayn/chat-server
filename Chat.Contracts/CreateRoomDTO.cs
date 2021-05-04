using System;

namespace Chat.Contracts
{
    public class CreateRoomDTO
    {
        public Guid[] UserIds { get; set; }
    }
}
