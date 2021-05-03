using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Contracts
{
    public class UpdateMessageDTO
    {
        public Guid UserId { get; set; }
        public Guid RoomId { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public Guid Id { get; set; }
    }
}
