using EnterpriseAI.Application.AI.Models;

namespace EnterpriseAI.Application.Conversations.StreamMessage
{
    public class StreamMessageResult
    {
        public required IAsyncEnumerable<AppChatChunk> Stream { get; init; }
    }
}
