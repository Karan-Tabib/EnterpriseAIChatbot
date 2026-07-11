
using EnterpriseAI.Application.Abstractions.Persistence.Repositories;
using EnterpriseAI.Domain;
using EnterpriseAI.Infrastructure.Persistence.Context;
namespace EnterpriseAI.Infrastructure.Persistence.Repositories
{
    public class MessagesRepository :IMessagesRepository
    {
        private readonly AppDbContext _context;
        public MessagesRepository(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task AddAsync(Message message, CancellationToken cancellationToken)
        {
            await _context.Messages.AddAsync(message, cancellationToken);
        }
    }

}
