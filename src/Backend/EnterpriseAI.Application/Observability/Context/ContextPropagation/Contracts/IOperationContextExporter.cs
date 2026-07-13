namespace EnterpriseAI.Application.Observability.Context.ContextPropagation.Contracts
{
    public interface IOperationContextExporter<TTarget>
    {
        void Export(
            OperationContext context,
            TTarget target);
    }

}
