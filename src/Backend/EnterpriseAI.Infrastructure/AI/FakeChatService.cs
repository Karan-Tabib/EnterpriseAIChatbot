using EnterpriseAI.Application.AI.Contracts;
using EnterpriseAI.Application.AI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseAI.Infrastructure.AI
{
  
    public sealed class FakeChatService : IChatService
    {

        public Task<AppChatResponse> SendAsync(
            AppChatRequest request,
            CancellationToken cancellationToken)
        {
            return Task.FromResult(new AppChatResponse
            {
                Content = "This is a fake AI response."
            });
        }

        public IAsyncEnumerable<AppChatChunk> StreamAsync(AppChatRequest request, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
