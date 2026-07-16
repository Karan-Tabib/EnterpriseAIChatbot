namespace EnterpriseAI.Domain.Conversations
{

    public sealed class MemoryContext
    {
        public IReadOnlyList<Message> Messages { get; init; } = [];

        public string? ConversationSummary { get; init; }

        //public IReadOnlyList<RetrievedDocument> Documents { get; init; } = [];

        ///public UserMemory? UserProfile { get; init; }

        //public IReadOnlyList<ToolResult> ToolResults { get; init; } = [];

         public string? Summary { get; init; }

        public IReadOnlyDictionary<string, string> Facts { get; init; }
            = new Dictionary<string, string>();
    }
}
