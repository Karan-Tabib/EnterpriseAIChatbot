using EnterpriseAI.Application.AI.Models;
using EnterpriseAI.Infrastructure.AI.Ollama.Models;

namespace EnterpriseAI.Infrastructure.AI.Ollama
{
    public static class OllamaMappingExtensions
    {
        public static OllamaChatRequest ToOllamaRequest(
            this ChatRequest request,
            string model)
        {
            return new OllamaChatRequest
            {
                Model = model,
                Stream = false,
                Messages = request.Messages
                    .Select(m => new OllamaMessage
                    {
                        Role = m.Role.ToString().ToLower(),
                        Content = m.Content
                    })
                    .ToList()
            };
        }
    }
}
