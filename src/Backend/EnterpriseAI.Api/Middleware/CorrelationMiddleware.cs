using EnterpriseAI.Application.Observability.Context;
using EnterpriseAI.Application.Observability.Correlation;
using EnterpriseAI.Infrastructure.Observability;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace EnterpriseAI.Api.Middleware
{
    public class CorrelationMiddleware
    {
        public const string HeaderName = "X-Correlation-ID";

        private readonly RequestDelegate _next;

        private readonly ICorrelationIdGenerator _correlationIdGenerator;
        private readonly ILogger<CorrelationMiddleware> _logger;
        public CorrelationMiddleware(RequestDelegate next,
            ICorrelationIdGenerator correlationIdGenerator,
            ILogger<CorrelationMiddleware> logger)
        {
            _next = next;
            _correlationIdGenerator = correlationIdGenerator;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string correlationId;

            if (context.Request.Headers.TryGetValue(HeaderName, out var header) &&
                !string.IsNullOrWhiteSpace(header))
            {
                correlationId = header!;
            }
            else
            {
                correlationId = _correlationIdGenerator.Generate();
            }

            var accessor = context.RequestServices.GetRequiredService<IOperationContextAccessor>();
            
            var operation = accessor.Context;
            operation.CorrelationId = correlationId;
            operation.TraceId = Activity.Current?.TraceId.ToString() ?? string.Empty;
            operation.SpanId = Activity.Current?.SpanId.ToString() ?? string.Empty;
            operation.RequestId = context.TraceIdentifier;
            operation.StartedOnUtc = DateTime.UtcNow;

            context.Items[HeaderName] = correlationId;

            context.Response.OnStarting(() =>
            {
                context.Response.Headers[HeaderName] = correlationId;
                return Task.CompletedTask;
            });

            using (_logger.BeginScope(new Dictionary<string, object>
            {
                ["TraceId"] = operation.TraceId,
                ["CorrelationId"] = operation.CorrelationId,
                ["RequestName"] = operation.RequestName!,
                ["RequestId"] = operation.RequestId
            }))
            {
                 await _next(context);
            }
        }
    }
}
