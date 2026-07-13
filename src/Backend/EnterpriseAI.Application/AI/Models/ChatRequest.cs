namespace EnterpriseAI.Application.AI.Models
{
    //public class ChatRequest
    //{
    //    public string Content { get; set; } = string.Empty;
    //}

    public sealed class ChatRequest
    {
        public required IReadOnlyCollection<ChatMessage> Messages { get; init; }

        public double Temperature { get; init; } = 0.2;

        public int MaxTokens { get; init; } = 4000;
    }

}
