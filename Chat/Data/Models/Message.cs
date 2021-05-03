using System;

namespace Chat.Repository.Models
{
    public class Message
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public Guid RoomId { get; set; }
        public Guid UserId { get; set; }
        public bool IsDeletedForOwner { get; set; }
        public string RepliedMessageContent { get; set; }

        public virtual Room Room { get; set; }
        public virtual User User { get; set; }
    }
}
