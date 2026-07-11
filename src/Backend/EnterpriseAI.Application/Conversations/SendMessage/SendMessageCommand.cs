using MediatR;
using System;

namespace EnterpriseAI.Application.Conversations.SendMessage
{
    public class SendMessageCommand :IRequest<SendMessageResult>
    {
        public string Content { get; set; }
        public Guid ConversationId { get; set; }
        public SendMessageCommand(Guid Id,string content)
        {
            ConversationId = Id;
            Content = content;
        }
    }

}
