using EnterpriseAI.Application.AI.Contracts;
using EnterpriseAI.Application.AI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseAI.Infrastructure.AI
{
  
    public sealed class FakeChatService : IChatService
    {

        public Task<ChatResponse> SendAsync(
            ChatRequest request,
            CancellationToken cancellationToken)
        {
            return Task.FromResult(new ChatResponse
            {
                Content = "This is a fake AI response."
            });
        }
    }
}
