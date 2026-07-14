namespace EnterpriseAI.Infrastructure.AI.Ollama.Models
{
    public sealed class OllamaChatResponse
    {
        public OllamaMessage Message { get; set; } = new();
    }
}
