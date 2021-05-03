using System;

namespace Chat.Contracts
{
    public class CreateMessageDTO
    {
        public Guid UserId { get; set; }
        public Guid RoomId { get; set; }
        public string Content { get; set; }
        public string RepliedMessageContent { get; set; }
    }
}
