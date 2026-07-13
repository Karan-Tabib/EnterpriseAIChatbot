using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseAI.Application.Observability.Context
{
    public interface IOperationContextAccessor
    {
        OperationContext Context { get; }
    }
}
