using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using EnterpriseAI.Infrastructure.Persistence.Repositories;
using EnterpriseAI.Infrastructure.Persistence.Context;
using EnterpriseAI.Application.Abstractions.Persistence.Repositories;
using EnterpriseAI.Infrastructure.Persistence.UnitOfWork;
namespace EnterpriseAI.Infrastructure.ExtensionsRegistration
{
    public static class InfrastructureExtension
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddDatabaseService(services, configuration);
            AddRepositories(services);
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
    }
}
