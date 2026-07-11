namespace EnterpriseAI.Application.Conversations.RenameConversation
{
    public class RenameConversationResult
    {
        public Guid ConversationId { get; init; }

        public string Title { get; init; } = string.Empty;

        public DateTime CreatedOn { get; init; }
        public DateTime UpdatedOn { get; init; }
    }
}
