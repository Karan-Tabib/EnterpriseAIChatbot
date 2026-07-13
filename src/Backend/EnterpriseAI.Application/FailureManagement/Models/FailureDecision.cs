using Microsoft.Extensions.Logging;

namespace EnterpriseAI.Application.FailureManagement.Models
{
    /*
     * FailureResult
│
        ├── StatusCode
        ├── ErrorCode
        ├── Title
        ├── Detail
        ├── Severity
        ├── Category
        ├── IsRecoverable
        ├── ShouldRetry
        ├── ShouldAlert
        ├── ShouldLog
        ├── LogLevel
        ├── RetryAfter
        └── Metadata

    FailureDecision
        
        ├── Category
        ├── Severity
        ├── ErrorCode
        ├── RetryPolicy
        ├── Recoverable
        ├── LogLevel
        ├── Alert
        ├── PublishEvent
        ├── DeadLetter
        ├── UserMessage
        ├── DeveloperMessage
        ├── CorrelationId
        ├── Metadata
        └── Telemetry
     */
    public sealed class FailureDecision
    {

        public required string Title { get; init; }

        public required string ErrorCode { get; init; }

        public required string Detail { get; init; }

        public FailureCategory Category { get; init; }

        public FailureSeverity Severity { get; init; }

        public RecoveryAction RecoveryAction { get; init; }

        public bool IsRecoverable { get; init; }

        public LogLevel LogLevel { get; init; }

        public IDictionary<string, object?> Extensions { get; } = new Dictionary<string, object?>();
        public bool Recoverable { get; init; }
    }


}
