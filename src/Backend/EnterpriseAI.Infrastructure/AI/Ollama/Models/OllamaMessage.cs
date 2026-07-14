namespace EnterpriseAI.Infrastructure.AI.Ollama.Models
{
    public sealed class OllamaMessage
    {
        public string Role { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;
    }
}
