namespace EnterpriseAI.Application.AI.Contracts
{
    public interface IEmbeddingService
    {
        Task<float[]> GenerateEmbeddingAsync(string text, CancellationToken cancellationToken);
    }
}
