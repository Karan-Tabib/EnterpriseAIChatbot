namespace EnterpriseAI.Application.Observability.Context.ContextPropagation.Contracts
{
    public interface IOperationContextPropagation<TSource, TTarget>
    {
        OperationContext Import(TSource source);

        void Export(
            OperationContext context,
            TTarget target);
    }

}
