using MediatR;
using System;

namespace EnterpriseAI.Application.Conversations.SendMessage
{
    public sealed record SendMessageCommand(Guid ConversationId, string Message) : IRequest<SendMessageResult>;

}
