namespace EnterpriseAI.Application.AI.Models
{
    public sealed class AppChatChunk
    {
        public string Content { get; init; } = string.Empty;

        public bool IsCompleted { get; init; }

        public string? FinishReason { get; init; }
    }
}