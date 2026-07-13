using EnterpriseAI.Api.FailureManagement.Contracts;
using EnterpriseAI.Application.FailureManagement.Models;
using EnterpriseAI.Application.FailureManagement.Contracts;
using Microsoft.AspNetCore.Diagnostics;

namespace EnterpriseAI.Api.FailureManagement
{
    public sealed class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly IFailureStrategyResolver _strategyResolver;
        private readonly IFailureResponseWriter _responseWriter;

        public GlobalExceptionHandler(
            IFailureStrategyResolver strategyResolver,
            IFailureResponseWriter responseWriter)
        {
            _strategyResolver = strategyResolver;
            _responseWriter = responseWriter;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var failureContext = new FailureContext
            {
                Exception = exception,
                TraceId = httpContext.TraceIdentifier,
                Timestamp = DateTime.UtcNow
            };

            var strategy = _strategyResolver.Resolve(failureContext);


            var failureResult = await strategy.ExecuteAsync(failureContext, cancellationToken);

            await _responseWriter.WriteAsync(
                httpContext,
                failureResult,
                cancellationToken);

            return true;
        }
    }
}
