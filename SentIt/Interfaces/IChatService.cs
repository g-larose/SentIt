using SentIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentIt.Interfaces
{
    public interface IChatService
    {
        Task<ChatMessage> BroadcastMessageAsync();
    }
}
