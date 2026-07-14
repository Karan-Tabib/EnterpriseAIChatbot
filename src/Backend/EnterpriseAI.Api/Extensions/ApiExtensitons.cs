using EnterpriseAI.Api.Options;
using EnterpriseAI.APi.FailureManagement.Extensions;
using EnterpriseAI.Application.Abstractions;

namespace EnterpriseAI.Api.Extensions
{
    public static class ApiExtensitons
    {
        public static IServiceCollection AddAPIExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PerformanceLoggingOptions>(configuration.GetSection(PerformanceLoggingOptions.SectionName));
            
            services.AddFailureManagement();
            services.AddSingleton<IPerformanceSettings, PerformanceSettings>();
            return services;
        }
    }
}
