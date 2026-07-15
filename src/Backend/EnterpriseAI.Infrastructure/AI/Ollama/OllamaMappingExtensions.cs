using EnterpriseAI.Application.AI.Models;
using EnterpriseAI.Infrastructure.AI.Ollama.Models;

namespace EnterpriseAI.Infrastructure.AI.Ollama
{
    public static class OllamaMappingExtensions
    {
        public static OllamaRequest ToOllamaRequest(
            this AppChatRequest request,
            string model)
        {
            return new OllamaRequest
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
