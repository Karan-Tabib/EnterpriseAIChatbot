using EnterpriseAI.Application.AI.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace EnterpriseAI.Infrastructure.AI.Ollama.DependencyInjection
{
    public static class OllamaExtension
    {
        public static IServiceCollection AddOllama(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<IChatService, OllamaChatService>((sp, client) =>
            {
                var options = sp.GetRequiredService<IOptions<OllamaOptions>>().Value;

                client.BaseAddress = new Uri(options.BaseUrl);
            });

            return services;
        }
    }
}
