using SentIt.Interfaces;
using SentIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentIt.Services
{
    public class ChatService : IChatService
    {
        public async Task<ChatMessage> BroadcastMessageAsync()
        {
            throw new NotImplementedException();
        }
    }
}
