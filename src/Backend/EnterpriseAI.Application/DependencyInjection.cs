using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using FluentValidation;
using MediatR;
using EnterpriseAI.Application.Behaviors;
using EnterpriseAI.Application.AI.Contracts;
using EnterpriseAI.Application.AI;
using EnterpriseAI.Application.AI.Prompting;
using EnterpriseAI.Application.AI.Memory;
using EnterpriseAI.Application.AI.Prompting.PrompSectionBuilder;

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
            AddPrompting(services, configuration);
            AddMemoryManagement(services, configuration);



            return services;
        }

        private static IServiceCollection AddPrompting(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPromptBuilder, PromptBuilder>();
            services.AddSingleton<ISystemPromptProvider, DefaultSystemPromptProvider>();

            services.AddScoped<IPromptSectionBuilder, SystemPromptBuilder>();
            services.AddScoped<IPromptSectionBuilder, ConversationHistoryBuilder>();
            services.AddScoped<IPromptSectionBuilder, SummaryPromptBuilder>();
            services.AddScoped<IPromptSectionBuilder, RetrievedDocumentBuilder>();

            return services;
        }

        private static IServiceCollection AddMemoryManagement(IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IMemoryManager, ConversationMemoryManager>();
            services.AddScoped<IMemorySelectionStrategy, SlidingWindowMemoryStrategy>();

            return services;
        }
    }
}
