using System.Text.Json;
namespace EnterpriseAI.Api.Common.Sse
{

    public sealed class SseWriter
    {
        /// <summary>
        /// Configures the HTTP response for Server-Sent Events.
        /// </summary>
        public static void Configure(HttpResponse response)
        {
            response.ContentType = "text/event-stream";
            response.Headers.CacheControl = "no-cache";
            response.Headers.Connection = "keep-alive";
        }

        /// <summary>
        /// Writes a standard SSE message.
        /// </summary>
        public static async Task WriteAsync<T>(HttpResponse response, T data, CancellationToken cancellationToken = default)
        {
            var json = JsonSerializer.Serialize(data);

            await response.WriteAsync(
                $"data: {json}\n\n",
                cancellationToken);

            await response.Body.FlushAsync(cancellationToken);
        }

        /// <summary>
        /// Writes a named SSE event.
        /// Example:
        /// event: done
        /// data: {}
        /// </summary>
        public static async Task WriteEventAsync<T>(HttpResponse response, string eventName, T data,
            CancellationToken cancellationToken = default)
        {
            var json = JsonSerializer.Serialize(data);

            await response.WriteAsync(
                        $"""
                    event: {eventName}
                    data: {json}
                    
                    """,
            cancellationToken);

            await response.Body.FlushAsync(cancellationToken);
        }

        /// <summary>
        /// Writes an SSE comment.
        /// Browsers ignore comments.
        /// Useful for heartbeats.
        /// </summary>
        public static async Task WriteCommentAsync(HttpResponse response, string comment, CancellationToken cancellationToken = default)
        {
            await response.WriteAsync(
                $": {comment}\n\n",
                cancellationToken);

            await response.Body.FlushAsync(cancellationToken);
        }
    }
}
