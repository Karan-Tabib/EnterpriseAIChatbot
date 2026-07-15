

using EnterpriseAI.Application.AI.Models;
using MediatR;

namespace EnterpriseAI.Application.Conversations.StreamMessage
{
    public sealed record StreamMessageCommand(Guid ConversationId, string Message) : IRequest<IAsyncEnumerable<AppChatChunk>>;
}
