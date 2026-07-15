using EnterpriseAI.Application.AI.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OllamaSharp;

namespace EnterpriseAI.Infrastructure.AI.Ollama.DependencyInjection
{
    public static class OllamaServiceCollectionExtensions
    {
        public static IServiceCollection AddOllama(this IServiceCollection services, IConfiguration configuration)
        {

            //services.AddHttpClient<IChatService, OllamaChatService>((sp, client) =>
            //{
            //    var options = sp.GetRequiredService<IOptions<OllamaOptions>>().Value;

            //    client.BaseAddress = new Uri(options.BaseUrl);
            //    client.Timeout = TimeSpan.FromSeconds(60);

            //    client.DefaultRequestHeaders.Add(
            //        "User-Agent",
            //        "EnterpriseAI");
            //});


            services.Configure<OllamaOptions>(configuration.GetSection(OllamaOptions.SectionName));

            services.AddSingleton<IOllamaApiClient>(sp =>
            {
                var options = sp.GetRequiredService<IOptions<OllamaOptions>>().Value;

                var client = new OllamaApiClient(options.BaseUrl, options.Model);
                return client;
            });

            services.AddScoped<IChatService, OllamaChatService>();

            return services;
        }
    }
}
