using EnterpriseAI.Domain.Conversations;
using EnterpriseAI.Domain;

namespace EnterpriseAI.Application.AI.Memory
{
    public interface IMemoryManager
    {
        Task<MemoryContext> BuildAsync(
            Conversation conversation,
            CancellationToken cancellationToken);
    }
}
