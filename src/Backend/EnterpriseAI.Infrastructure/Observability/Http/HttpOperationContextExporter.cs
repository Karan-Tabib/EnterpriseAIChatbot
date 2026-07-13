using EnterpriseAI.Application.Observability.Context.ContextPropagation.Contracts;

namespace EnterpriseAI.Application.Observability.Context.ContextPropagation.Http
{
    public sealed class HttpOperationContextExporter
    : IOperationContextExporter<HttpRequestMessage>
    {
        public void Export(
            OperationContext context,
            HttpRequestMessage request)
        {
            throw new NotImplementedException();
        }
    }

}
