using System;

namespace Chat.Contracts
{
    public class MessageDTO
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public Guid RoomId { get; set; }
        public Guid UserId { get; set; }
        public bool IsDeletedForOwner { get; set; }
        public string RepliedMessageContent { get; set; }
    }
}
