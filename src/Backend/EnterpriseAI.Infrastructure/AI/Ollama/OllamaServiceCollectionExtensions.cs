
using EnterpriseAI.Application.AI.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace EnterpriseAI.Infrastructure.AI.Ollama
{
    public static class OllamaServiceCollectionExtensions
    {
        public static IServiceCollection AddOllama(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<OllamaOptions>(configuration.GetSection(OllamaOptions.SectionName));

            services.AddHttpClient<IChatService, OllamaChatService>((sp, client) =>
            {
                var options = sp.GetRequiredService<IOptions<OllamaOptions>>().Value;

                client.BaseAddress = new Uri(options.BaseUrl);
                client.Timeout = TimeSpan.FromSeconds(60);

                client.DefaultRequestHeaders.Add(
                    "User-Agent",
                    "EnterpriseAI");
            });

            return services;
        }
    }
    ;
}
