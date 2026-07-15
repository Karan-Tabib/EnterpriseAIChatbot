using EnterpriseAI.Application.AI.Models;
using System.Runtime.CompilerServices;

namespace EnterpriseAI.Application.AI.Contracts
{
    public interface IChatService
    {
        //Task<ChatResponse> GenerateAsync(ChatRequest request, CancellationToken cancellationToken);
       // Task<AppChatResponse> SendAsync(AppChatRequest request, CancellationToken cancellationToken);
        Task<AppChatResponse> SendAsync(AppChatRequest request, CancellationToken cancellationToken);
        IAsyncEnumerable<AppChatChunk> StreamAsync(AppChatRequest request,
                [EnumeratorCancellation] CancellationToken cancellationToken);
    }
}
