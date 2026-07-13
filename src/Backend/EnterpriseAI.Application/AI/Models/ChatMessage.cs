namespace EnterpriseAI.Application.AI.Models
{
    public sealed class ChatMessage
    {
        public ChatRole Role { get; init; }

        public string Content { get; init; } = string.Empty;
    }
}
