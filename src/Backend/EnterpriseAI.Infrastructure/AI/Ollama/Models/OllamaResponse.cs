namespace EnterpriseAI.Infrastructure.AI.Ollama.Models
{

    public sealed class OllamaResponse
    {
        public string Model { get; set; } = string.Empty;

        public OllamaMessage Message { get; set; } = new();

        public bool Done { get; set; }
    }
}
