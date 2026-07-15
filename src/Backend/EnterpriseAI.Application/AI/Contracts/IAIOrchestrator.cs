using EnterpriseAI.Application.AI.Models;

namespace EnterpriseAI.Application.AI.Contracts
{
    public interface IAIOrchestrator
    {
        Task<AppChatResponse> GenerateResponseAsync(Guid conversationId, string userMessage, CancellationToken cancellationToken);
        IAsyncEnumerable<AppChatChunk> StreamResponseAsync(Guid conversationId, string userMessage,
            CancellationToken cancellationToken);
    }
}