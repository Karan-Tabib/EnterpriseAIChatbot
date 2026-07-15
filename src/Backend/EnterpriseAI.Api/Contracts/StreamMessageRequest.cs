namespace EnterpriseAI.Api.Contracts
{
    public sealed class StreamMessageRequest
    {
        public Guid ConversationId { get; init; }

        public required string Message { get; init; }
    }

}
