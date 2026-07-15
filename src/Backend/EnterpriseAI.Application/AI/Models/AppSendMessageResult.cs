namespace EnterpriseAI.Application.AI.Models
{
    public sealed class SendMessageResult
    {
        public Guid ConversationId { get; init; }

        public Guid MessageId { get; init; }

        public DateTime CreatedAt { get; init; }

        public string Content { get; init; } = string.Empty;
    }


}

