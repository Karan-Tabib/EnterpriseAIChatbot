using EnterpriseAI.Domain;

namespace EnterpriseAI.Application.Abstractions.Persistence.Repositories
{
    public interface IMessagesRepository
    {
        Task AddAsync(Message message, CancellationToken token);
    }

}
