using MediatR;
using MediatR;

namespace EnterpriseAI.Application.Conversations.GetConversation
{
    public sealed record GetConversationQuery(Guid ConversationId)
        : IRequest<GetConversationResult>;
}
