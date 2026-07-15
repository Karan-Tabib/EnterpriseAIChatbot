namespace EnterpriseAI.Application.AI.Models
{
    //public class ChatRequest
    //{
    //    public string Content { get; set; } = string.Empty;
    //}

    public sealed class AppChatRequest
    {
        public required IReadOnlyCollection<AppChatMessage> Messages { get; init; }

        public double Temperature { get; init; } = 0.2;

        public int MaxTokens { get; init; } = 4000;

      //  public IReadOnlyCollection<AppTool>? Tools { get; init; }

        public string? ResponseFormat { get; init; }

        public bool Stream { get; init; }

        public IReadOnlyDictionary<string, object>? Metadata { get; init; }
    }

    public sealed class ChatRequestDTO
    {
        public string Content { get; set; }
    }

}
