using EnterpriseAI.Api.Options;
using EnterpriseAI.APi.FailureManagement.Extensions;
using EnterpriseAI.Application.Abstractions;

namespace EnterpriseAI.Api.Extensions
{
    public static class ApiExtensitons
    {
        public static IServiceCollection AddAPIExtensions(this IServiceCollection services, IConfiguration configuariton)
        {
            services.AddFailureManagement();
            services.AddSingleton<IPerformanceSettings, PerformanceSettings>();
            return services;
        }
    }
}
