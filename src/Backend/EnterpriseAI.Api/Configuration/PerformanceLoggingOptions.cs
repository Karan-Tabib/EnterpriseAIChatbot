namespace EnterpriseAI.Api.Options
{
    public sealed class PerformanceLoggingOptions
    {
        public const string SectionName = "PerformanceLogging";

        public int SlowRequestThresholdMs { get; init; } = 1000;
    }

    public sealed class TelemetryOptions
    {

    }
}
