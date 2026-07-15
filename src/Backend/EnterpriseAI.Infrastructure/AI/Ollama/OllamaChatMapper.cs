
using EnterpriseAI.Application.AI.Models;

using OllamaSharp.Models.Chat;

namespace EnterpriseAI.Infrastructure.AI.Ollama
{
    internal static class OllamaChatMapper
    {

        public static ChatRequest ToRequest(AppChatRequest request, bool stream = false)
        {
            return new ChatRequest
            {
                Stream = stream,
                Messages = request.Messages
                    .Select(m => new Message
                    {
                        Role = MapRole(m.Role),
                        Content = m.Content
                    })
                    .ToList()
            };
        }

        public static AppChatResponse ToResponse(ChatResponseStream response)
        {
            return new AppChatResponse
            {
                Content = response.Message.Content
            };
        }


        public static AppChatChunk ToChunk(ChatResponseStream response)
        {
            return new AppChatChunk
            {
                Content = response.Message.Content,
                IsCompleted = response.Done
            };
        }

        private static string MapRole(AppChatRole role)
        {
            return role switch
            {
                AppChatRole.System => "system",
                AppChatRole.User => "user",
                AppChatRole.Assistant => "assistant",
                _ => throw new InvalidOperationException($"Unsupported role {role}")
            };
        }
    }

}