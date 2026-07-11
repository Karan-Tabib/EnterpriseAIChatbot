using EnterpriseAI.Domain;

namespace EnterpriseAI.Application.Abstractions.Persistence.Repositories
{
    public interface IConversationQueryRepository
    {
        Task<Conversation?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        Task<List<Message>?> GetMessagesAsync(Guid id, CancellationToken cancellationToken);
    }

    public interface IConversationMessageQueryRepository
    {
       
    }
}
