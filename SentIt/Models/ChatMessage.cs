using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentIt.Models
{
    public class ChatMessage
    {
        public Guid Id { get; set; }
        public string? Message { get; set; }
        public string? Author { get; set; }
        public DateTime Created { get; set; }
        public MessageType Type { get; set; }
    }
}
