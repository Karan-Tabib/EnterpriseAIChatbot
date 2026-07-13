
using EnterpriseAI.Application.AI.Models;

namespace EnterpriseAI.Application.AI.Contracts
{
    public interface IAIOrchestrator
    {
        Task<ChatResponse> GenerateResponseAsync(Guid conversationId, string userMessage,
            CancellationToken cancellationToken);
    }
}
