

using EnterpriseAI.Application.Abstractions;
using EnterpriseAI.Application.Observability.Context;
using EnterpriseAI.Application.Observability.Contracts;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace EnterpriseAI.Application.Behaviors
{
    public class PerformanceBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly ILogger<PerformanceBehavior<TRequest, TResponse>> _logger;
        private readonly IOperationContextAccessor _operationContext;
        private readonly IPerformanceLogFormatter _performanceFormatter;
        private readonly IPerformanceSettings _settings;


        public PerformanceBehavior(
            ILogger<PerformanceBehavior<TRequest, TResponse>> logger,
            IOperationContextAccessor operationContext,
            IPerformanceLogFormatter performanceFormatter,
              IPerformanceSettings settings)
        {
            _logger = logger;
            _performanceFormatter = performanceFormatter;
            _operationContext = operationContext;
            _settings = settings;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = _operationContext.Context;

            var sw = Stopwatch.StartNew();
            var response = await next();
            sw.Stop();
            var threshold = _settings.SlowRequestThresholdMs;
            bool isSlowRequest = sw.ElapsedMilliseconds >= 1000;
            _logger.LogInformation(_performanceFormatter.Format(context,
                                            sw.ElapsedMilliseconds, isSlowRequest
                                            ));
            return response;
        }
    }
}
