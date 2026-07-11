using EnterpriseAI.Domain;

namespace EnterpriseAI.Application.Abstractions.Persistence.Repositories
{
    public interface IConversationRepository
    {
        Task AddAsync(Conversation conversation, CancellationToken token);

        Task<Conversation?> GetConversationWithMessages(Guid id, CancellationToken cancellationToken);

//        Task<Conversation> GetConversationForUser(Guid id, CancellationToken cancellationToken);
        Task<Conversation> GetRecentConversations(Guid id, CancellationToken cancellationToken);
        Task ArchiveConversation(Guid id, CancellationToken cancellationToken);
        Task<Conversation?> DeleteConversation(Guid id, CancellationToken cancellationToken);
//        Task<Conversation?> RenameConversation(Guid id, CancellationToken cancellationToken);
    }

}
