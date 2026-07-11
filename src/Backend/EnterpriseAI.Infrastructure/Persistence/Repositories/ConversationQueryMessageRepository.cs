using EnterpriseAI.Application.Abstractions.Persistence.Repositories;
using EnterpriseAI.Application.Conversations.GetConversationMessages;
using EnterpriseAI.Domain;
using EnterpriseAI.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;


namespace EnterpriseAI.Infrastructure.Persistence.Repositories
{
    public class ConversationQueryMessageRepository : IConversationMessageQueryRepository
    {
        private readonly AppDbContext _context;
        public ConversationQueryMessageRepository(AppDbContext context)
        {
            _context = context;
        }
       
    }
}
