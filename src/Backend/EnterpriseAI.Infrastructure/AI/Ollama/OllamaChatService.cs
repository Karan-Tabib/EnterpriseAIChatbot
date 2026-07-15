using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using Confluent.Kafka;
using EnterpriseAI.Application.AI.Contracts;
using EnterpriseAI.Application.AI.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using OllamaSharp;

namespace EnterpriseAI.Infrastructure.AI.Ollama
{
    public sealed class OllamaChatService : IChatService
    {
        //private readonly HttpClient _httpClient;
        private readonly IOllamaApiClient _client;
        private readonly OllamaOptions _options;
        private readonly ILogger<OllamaChatService> _logger;

        public OllamaChatService(
            //HttpClient httpClient,
            IOllamaApiClient client,
            IOptions<OllamaOptions> options,
            ILogger<OllamaChatService> logger)
        {
            _client = client;
            _options = options.Value;
            _logger = logger;
        }

        
        public async Task<AppChatResponse> SendAsync(AppChatRequest request, CancellationToken cancellationToken)
        {
            /*
            // Convert Application model -> Ollama model
            var ollamaRequest = OllamaChatMapper.ToRequest(request);

             // Call Ollama
             var httpResponse = await _client.PostAsJsonAsync(
                "/api/chat",
                ollamaRequest,
                cancellationToken);


            httpResponse.EnsureSuccessStatusCode();

            // Deserialize
            var ollamaResponse =
                await httpResponse.Content.ReadFromJsonAsync<OllamaResponse>(cancellationToken: cancellationToken);

            if (ollamaResponse is null)
                throw new InvalidOperationException("Ollama returned an empty response.");

            // Convert Ollama model -> Application model
            return OllamaChatMapper.ToResponse(ollamaResponse);
            */
            return null;
        }
        


        public async IAsyncEnumerable<AppChatChunk> StreamAsync(AppChatRequest request, 
                [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var ollamaRequest = OllamaChatMapper.ToRequest(request,true);

            await foreach (var chunk in _client.ChatAsync(ollamaRequest, cancellationToken))
            {
                yield return OllamaChatMapper.ToChunk(chunk);
            }
        }
    }
}



