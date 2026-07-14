using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using FluentValidation;
using MediatR;
using EnterpriseAI.Application.Behaviors;
using EnterpriseAI.Application.AI.Contracts;
using EnterpriseAI.Application.AI;
using EnterpriseAI.Application.AI.Prompting;

namespace EnterpriseAI.Application
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            AddMediatRPipeline(services, configuration);

            AddAIOrchestrator(services, configuration);
         
            return services;
        }
        public static IServiceCollection AddMediatRPipeline(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            });

            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

            //This is your Application Pipeline Configuration.
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehavior<,>));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));
            return services;
        }
        public static IServiceCollection AddAIOrchestrator(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IAIOrchestrator, AIOrchestrator>();
            services.AddScoped<IPromptBuilder, PromptBuilder>();
            services.AddSingleton<ISystemPromptProvider, DefaultSystemPromptProvider>();
            return services;
        }
    }
}
