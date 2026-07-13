using EnterpriseAI.Application.Abstractions;
using Microsoft.Extensions.Options;

namespace EnterpriseAI.Api.Options
{
    public sealed class PerformanceSettings
    : IPerformanceSettings
    {
        private readonly PerformanceLoggingOptions _options;

        public PerformanceSettings(
            IOptions<PerformanceLoggingOptions> options)
        {
            _options = options.Value;
        }

        public int SlowRequestThresholdMs =>
            _options.SlowRequestThresholdMs;
    }
}
