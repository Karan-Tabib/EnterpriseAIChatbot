using EnterpriseAI.Application.Conversations.GetConversation;
using MediatR;

namespace EnterpriseAI.Application.Conversations.GetConversationMessages
{
    public sealed record GetConversationMessagesQuery(Guid ConversationId) : 
        IRequest<List<GetConversationMessagesResult>>;
   
}
