using EnterpriseAI.Application.Observability.Correlation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseAI.Infrastructure.Observability
{
    public sealed class CorrelationIdGenerator : ICorrelationIdGenerator
    {
        public string Generate() => Guid.NewGuid().ToString("N");
    }
}
