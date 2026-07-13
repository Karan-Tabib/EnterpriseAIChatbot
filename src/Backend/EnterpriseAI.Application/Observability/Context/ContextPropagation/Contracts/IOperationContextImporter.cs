namespace EnterpriseAI.Application.Observability.Context.ContextPropagation.Contracts
{
    public interface IOperationContextImporter<TSource>
    {
        OperationContext Import(TSource source);
    }

}
