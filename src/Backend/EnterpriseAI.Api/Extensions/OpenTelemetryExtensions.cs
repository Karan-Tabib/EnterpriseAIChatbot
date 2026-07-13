using EnterpriseAI.Contracts.Constants;
using System.Diagnostics;

namespace EnterpriseAI.Api.Extensions
{
    public static class OpenTelemetryExtensions
    {
        public static IServiceCollection AddEnterpriseTelemetry(
            this IServiceCollection services,
            IConfiguration configuration)

        {
            services.AddSingleton(new ActivitySource(TelemetryConstants.ActivitySource));
            return services;
        }

    }
}
