

namespace EnterpriseAI.Infrastructure.AI.Ollama.Chat
{
    public sealed class ChatChunk
    {
        public string Content { get; init; } = string.Empty;

        public bool IsCompleted { get; init; }
    }
}
