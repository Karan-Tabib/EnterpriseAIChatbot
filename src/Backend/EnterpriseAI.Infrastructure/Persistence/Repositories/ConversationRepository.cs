
using EnterpriseAI.Application.Abstractions.Persistence.Repositories;
using EnterpriseAI.Domain;
using EnterpriseAI.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
namespace EnterpriseAI.Infrastructure.Persistence.Repositories
{
    public class ConversationRepository : IConversationRepository
    {
        private readonly AppDbContext _context;
        public ConversationRepository(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task AddAsync(Conversation conversation, CancellationToken cancellationToken)
        {
            await _context.Conversations.AddAsync(conversation, cancellationToken);
        }
        public Task<Conversation?> GetConversationWithMessages(Guid id, CancellationToken cancellationToken)
        {
            return _context.Conversations
                .Include(x => x.Messages)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public Task ArchiveConversation()
        {
            throw new NotImplementedException();
        }

        public  async Task<Conversation> DeleteConversation(Guid id, CancellationToken cancellationToken)
        {
            var conversation = await _context.Conversations
         .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            if (conversation is null)
            {
                return null;
            }

            _context.Conversations.Remove(conversation);

            return conversation;
        }


        public Task<Conversation> GetRecentConversations(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task ArchiveConversation(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

}
