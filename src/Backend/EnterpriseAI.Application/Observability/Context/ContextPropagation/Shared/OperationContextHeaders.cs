using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseAI.Application.Observability.Context.ContextPropagation.Shared
{
    public static class OperationContextHeaders
    {
        public const string CorrelationId = "X-Correlation-ID";

        public const string TraceId = "X-Trace-ID";

        public const string SpanId = "X-Span-ID";

        public const string UserId = "X-User-ID";

        public const string TenantId = "X-Tenant-ID";
    }
}
