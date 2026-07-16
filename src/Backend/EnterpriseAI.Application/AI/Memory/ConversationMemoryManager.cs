using EnterpriseAI.Domain.Conversations;
using EnterpriseAI.Domain;


namespace EnterpriseAI.Application.AI.Memory
{
    public sealed class ConversationMemoryManager : IMemoryManager
    {
        private IMemorySelectionStrategy _memorySelectionStrategy;
        public ConversationMemoryManager(IMemorySelectionStrategy memorySelectionStrategy)
        {
            _memorySelectionStrategy = memorySelectionStrategy;
        }

        public Task<MemoryContext> BuildAsync(
            Conversation conversation,
            CancellationToken cancellationToken)
        {

            var messages = _memorySelectionStrategy.Select(conversation.Messages, cancellationToken);

            var context = new MemoryContext
            {
                Messages = messages
            };

            return Task.FromResult(context);
        }
    }
}
