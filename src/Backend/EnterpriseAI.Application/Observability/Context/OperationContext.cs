namespace EnterpriseAI.Application.Observability.Context
{
    public sealed class OperationContext
    {
        public string TraceId { get; set; } = string.Empty;

        public string SpanId { get; set; } = string.Empty;

        public string CorrelationId { get; set; } = string.Empty;

        public string RequestId { get; set; } = string.Empty;

        public string? UserId { get; set; }

        public string? TenantId { get; set; }

        public string? RequestName { get; set; }

        public DateTime StartedOnUtc { get; set; }
    }
}
