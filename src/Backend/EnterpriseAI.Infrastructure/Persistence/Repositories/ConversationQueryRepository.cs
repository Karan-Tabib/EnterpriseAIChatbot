using EnterpriseAI.Application.Abstractions.Persistence.Repositories;
using EnterpriseAI.Application.Conversations.GetConversationMessages;
using EnterpriseAI.Domain;
using EnterpriseAI.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;


namespace EnterpriseAI.Infrastructure.Persistence.Repositories
{
    public class ConversationQueryRepository : IConversationQueryRepository
    {
        private readonly AppDbContext _context;
        public ConversationQueryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Conversation?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Conversations
                .Include(x => x.Messages)
                .AsSplitQuery()
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }


        public async Task<List<Message>?> GetMessagesAsync(Guid conversationId, CancellationToken cancellationToken)
        {
            return await _context.Messages
               .Where(m => EF.Property<Guid>(m, "ConversationId") == conversationId)
               .OrderBy(m => m.CreatedOn)
               .ToListAsync(cancellationToken);
        }
    }
}
