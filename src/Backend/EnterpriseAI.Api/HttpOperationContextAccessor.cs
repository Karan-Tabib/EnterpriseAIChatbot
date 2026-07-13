using EnterpriseAI.Application.Observability.Context;
using EnterpriseAI.SharedKernel;

namespace EnterpriseAI.Api
{
    public class HttpOperationContextAccessor : IOperationContextAccessor
    {
        public OperationContext Context { get; } = new();
    }
}
