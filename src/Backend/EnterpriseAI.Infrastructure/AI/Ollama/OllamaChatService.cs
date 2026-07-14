using System.Net.Http.Json;
using EnterpriseAI.Application.AI.Contracts;
using EnterpriseAI.Application.AI.Models;
using EnterpriseAI.Infrastructure.AI.Ollama.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;


namespace EnterpriseAI.Infrastructure.AI.Ollama
{
    public sealed class OllamaChatService : IChatService
    {
        private readonly HttpClient _httpClient;
        private readonly OllamaOptions _options;
        private readonly ILogger<OllamaChatService> _logger;

        public OllamaChatService(
            HttpClient httpClient,
            IOptions<OllamaOptions> options,
            ILogger<OllamaChatService> logger)
        {
            _httpClient = httpClient;
            _options = options.Value;
            _logger = logger;
        }

        public async Task<ChatResponse> SendAsync(
            ChatRequest request,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation("Sending chat request to Ollama. Model: {Model}", _options.Model);

            // Convert application request -> Ollama request
            var ollamaRequest = request.ToOllamaRequest(_options.Model);

            // Send request
            var httpResponse = await _httpClient.PostAsJsonAsync("/api/chat", ollamaRequest, cancellationToken);

            // Throw if status code is not 2xx
            httpResponse.EnsureSuccessStatusCode();

            // Deserialize response
            var ollamaResponse =
                await httpResponse.Content.ReadFromJsonAsync<OllamaChatResponse>(
                    cancellationToken: cancellationToken);

            if (ollamaResponse is null)
            {
                throw new InvalidOperationException(
                    "Received an empty response from Ollama.");
            }

            _logger.LogInformation("Received response from Ollama.");

            // Convert Ollama response -> Application response
            return new ChatResponse
            {
                Content = ollamaResponse.Message.Content
            };
        }
    }
}
