using Microsoft.Extensions.Logging;

namespace EnterpriseAI.Application.FailureManagement.Models
{


    //Models
    /*
     * 
     * 
     * FailureContext
        │
        ├── Exception
        ├── TraceId
        ├── CorrelationId
        ├── RequestPath
        ├── UserId
        ├── RequestMethod
        ├── TenantId
        ├── Timestamp
        ├── ActivityId
        ├── Environment
        ├── Activity (OpenTelemetry)
        └── CancellationToken

     */

    public sealed class FailureContext
    {
        public required Exception Exception { get; init; }

        public string? TraceId { get; init; }

        public DateTime Timestamp { get; init; } = DateTime.UtcNow;

        public IDictionary<string, object?> Metadata { get; } =
            new Dictionary<string, object?>();
    }

}
