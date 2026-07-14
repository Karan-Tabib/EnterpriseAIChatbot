using EnterpriseAI.Application.AI.Models;

namespace EnterpriseAI.Application.AI.Contracts
{
    public interface IChatService
    {
        //Task<ChatResponse> GenerateAsync(ChatRequest request, CancellationToken cancellationToken);
        Task<ChatResponse> SendAsync(ChatRequest request, CancellationToken cancellationToken);
    }
}
