namespace EnterpriseAI.Application.AI.Models
{
    public sealed class AppChatResponse
    {
        public string Content { get; init; } = string.Empty;

        public int PromptTokens { get; init; }

        public int CompletionTokens { get; init; }

        public int TotalTokens { get; init; }

        public string? FinishReason { get; init; }
        public string? Model { get; init; }

    }


}

