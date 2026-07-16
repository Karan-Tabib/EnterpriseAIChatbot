using EnterpriseAI.Domain;
using Microsoft.Extensions.Options;


namespace EnterpriseAI.Application.AI.Memory
{
    public class SlidingWindowMemoryStrategy : IMemorySelectionStrategy
    {
        private int DefaultWindowSize;
        public SlidingWindowMemoryStrategy(IOptions<MemoryOptions> options)
        {
            DefaultWindowSize = options.Value.SlidingWindowSize;
        }
        
        public IReadOnlyList<Message> Select(IReadOnlyCollection<Message> messages, CancellationToken cancellationToken)
        {
           return messages
                .OrderByDescending(x => x.SequenceNumber)
                .Take(DefaultWindowSize)
                .OrderBy(x => x.SequenceNumber)
                .ToList();
        }
    }
}
