using EnterpriseAI.Domain;


namespace EnterpriseAI.Application.AI.Memory
{
    public interface IMemorySelectionStrategy
    {
        IReadOnlyList<Message> Select(IReadOnlyCollection<Message> messages, CancellationToken cancellationToken);
    }
}
