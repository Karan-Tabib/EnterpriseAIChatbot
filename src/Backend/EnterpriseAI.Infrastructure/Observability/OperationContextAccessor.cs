using EnterpriseAI.Application.Observability.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseAI.Infrastructure.Observability
{
    public sealed class OperationContextAccessor : IOperationContextAccessor
    {
        public OperationContext Context { get; } = new();
    }
}
