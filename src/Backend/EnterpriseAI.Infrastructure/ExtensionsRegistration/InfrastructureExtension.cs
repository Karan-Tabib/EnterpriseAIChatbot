using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using EnterpriseAI.Infrastructure.Persistence.Repositories;
using EnterpriseAI.Infrastructure.Persistence.Context;
using EnterpriseAI.Application.Abstractions.Persistence.Repositories;
using EnterpriseAI.Infrastructure.Persistence.UnitOfWork;
using EnterpriseAI.Application.Observability.Correlation;
using EnterpriseAI.Infrastructure.Observability;
using EnterpriseAI.Application.Observability.Context;
using EnterpriseAI.Application.Observability.Contracts;
using EnterpriseAI.Application.Observability.Logging.Formatters;
using EnterpriseAI.Infrastructure.ExceptionHandling;
namespace EnterpriseAI.Infrastructure.ExtensionsRegistration
{
    public static class InfrastructureExtension
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddDatabaseService(services, configuration);
            AddRepositories(services);
            AddObservability(services, configuration);
            AddFormatters(services, configuration);
            AddExeceptionTranslator(services, configuration);
            return services;
        }

        private static IServiceCollection AddDatabaseService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }
            );
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMessagesRepository, MessagesRepository>();
            services.AddScoped<IConversationRepository, ConversationRepository>();
            services.AddScoped<IConversationQueryRepository, ConversationQueryRepository>();
            //services.AddScoped<IConversationMessageQueryRepository, ConversationQueryMessageRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

        public static IServiceCollection AddObservability(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IOperationContextAccessor, OperationContextAccessor>();
            services.AddSingleton<ICorrelationIdGenerator, CorrelationIdGenerator>();

            return services;
        }

        public static IServiceCollection AddFormatters(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IRequestLogFormatter, RequestLogFormatter>();
            services.AddSingleton<IPerformanceLogFormatter, PerformanceLogFormatter>();
            services.AddSingleton<ITransactionLogFormatter, TransactionLogFormatter>();
            services.AddSingleton<IFailureLogFormatter, FailureLogFormatter>();

            return services;
        }

        public static IServiceCollection AddExeceptionTranslator(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDatabaseExceptionTranslator, SqlServerExceptionTranslator>();
            

            return services;
        }
    }
}
