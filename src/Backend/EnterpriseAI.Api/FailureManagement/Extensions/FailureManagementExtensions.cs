using EnterpriseAI.Api.FailureManagement.Contracts;
using EnterpriseAI.Api.FailureManagement.Mappers;
using EnterpriseAI.Api.FailureManagement.Writers;
using EnterpriseAI.Api.FailureManagement;
using EnterpriseAI.Application.FailureManagement.Contracts;
using EnterpriseAI.Application.FailureManagement.Strategies;
using EnterpriseAI.Application.FailureManagement.Resolver;

namespace EnterpriseAI.APi.FailureManagement.Extensions
{
    public static class FailureManagementExtensions
    {
        public static IServiceCollection AddFailureManagement(
            this IServiceCollection services)
        {
            // Strategies
            services.AddSingleton<IFailureStrategy, ValidationFailureStrategy>();
            services.AddSingleton<IFailureStrategy, BusinessFailureStrategy>();
            services.AddSingleton<IFailureStrategy, NotFoundFailureStrategy>();
            services.AddSingleton<IFailureStrategy, InfrastructureFailureStrategy>();
            services.AddSingleton<IFailureStrategy, TimeoutFailureStrategy>();
            services.AddSingleton<IUnknownFailureStrategy, UnknownFailureStrategy>();

            // Resolver
            services.AddSingleton<IFailureStrategyResolver, FailureStrategyResolver>();

            // Mapper
            services.AddSingleton<IFailureResponseMapper, FailureResponseMapper>();

            // Response Writer
            services.AddSingleton<IFailureResponseWriter, ProblemDetailsResponseWriter>();

            // Global Exception Handler
            services.AddExceptionHandler<GlobalExceptionHandler>();

            services.AddProblemDetails();

            return services;
        }
    }
}
