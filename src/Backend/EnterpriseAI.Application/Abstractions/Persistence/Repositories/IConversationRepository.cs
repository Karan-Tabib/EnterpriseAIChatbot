using EnterpriseAI.Domain;

namespace EnterpriseAI.Application.Abstractions.Persistence.Repositories
{
    public interface IConversationRepository
    {
        Task AddAsync(Conversation conversation, CancellationToken token);

        Task GetConversationWithMessages();
        Task GetConversationForUser();
        Task GetRecentConversations();
        Task ArchiveConversation();
        Task DeleteConversation();
    }
}
