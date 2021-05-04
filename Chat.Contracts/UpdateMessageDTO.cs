using System;

namespace Chat.Contracts
{
    public class UpdateMessageDTO
    {
        public string Content { get; set; }
        public Guid Id { get; set; }
    }
}
