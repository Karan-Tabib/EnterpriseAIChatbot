namespace EnterpriseAI.Application.AI.Models
{
    public sealed class ChatResponse
    {
        public string Content { get; init; } = string.Empty;

        public int PromptTokens { get; init; }

        public int CompletionTokens { get; init; }

        public int TotalTokens { get; init; }

        public string? FinishReason { get; init; }
        public string? Model { get; init; }
        public Guid MessageId { get; init; }

        public DateTime CreatedAt { get; init; }

    }
}

