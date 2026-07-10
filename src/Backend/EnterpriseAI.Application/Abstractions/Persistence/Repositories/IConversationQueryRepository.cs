using EnterpriseAI.Domain;

namespace EnterpriseAI.Application.Abstractions.Persistence.Repositories
{
    public interface IConversationQueryRepository
    {
        Task<Conversation?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
