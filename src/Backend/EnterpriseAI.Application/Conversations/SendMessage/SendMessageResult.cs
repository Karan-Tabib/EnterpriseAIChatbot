namespace EnterpriseAI.Application.Conversations.SendMessage
{
    public class SendMessageResult
    {
        public Guid ConversationId { get; set; }
        public Guid MessageId { get; set; }
        public string MessageContent { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }

}
