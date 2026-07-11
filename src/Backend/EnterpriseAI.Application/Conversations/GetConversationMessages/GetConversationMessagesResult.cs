using EnterpriseAI.Domain;

namespace EnterpriseAI.Application.Conversations.GetConversationMessages
{
    public class GetConversationMessagesResult
    {
        public Guid ConversationId { get;  set; }

        public Guid Id { get;  set; }

        public MessageRole Role { get;  set; }

        public string? Content { get;  set; }

        public DateTime CreatedOn { get;  set; }
    }
}
