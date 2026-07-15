namespace EnterpriseAI.Application.AI.Models
{
    public sealed class AppChatMessage
    {
        public AppChatRole Role { get; init; }

        public string Content { get; init; } = string.Empty;
    }
}
