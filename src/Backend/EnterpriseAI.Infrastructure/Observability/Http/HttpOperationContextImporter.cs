using EnterpriseAI.Application.Observability.Context.ContextPropagation.Contracts;
using Microsoft.AspNetCore.Http;

namespace EnterpriseAI.Application.Observability.Context.ContextPropagation.Http
{
    public sealed class HttpOperationContextImporter
    : IOperationContextImporter<HttpRequest>
    {
        public OperationContext Import(HttpRequest request)
        {
            throw new NotImplementedException();
        }
    }

}
