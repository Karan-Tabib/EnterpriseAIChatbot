
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


        public Task ArchiveConversation()
        {
            throw new NotImplementedException();
        }

        public Task DeleteConversation()
        {
            throw new NotImplementedException();
        }



        public Task GetConversationForUser()
        {
            throw new NotImplementedException();
        }

        public Task GetConversationWithMessages()
        {
            throw new NotImplementedException();
        }

        public Task GetRecentConversations()
        {
            throw new NotImplementedException();
        }
    }
}
