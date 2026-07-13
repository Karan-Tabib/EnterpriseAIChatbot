using EnterpriseAI.Application.Observability.Context;
using EnterpriseAI.Application.Observability.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
namespace EnterpriseAI.Application.Behaviors
{

    public sealed class LoggingBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;
        private readonly IOperationContextAccessor _operationContext;
        private readonly IRequestLogFormatter _requestFormatter;

        public LoggingBehavior(
            ILogger<LoggingBehavior<TRequest, TResponse>> logger,
            IOperationContextAccessor operationContext,
            IRequestLogFormatter requestLogFormatter)
        {
            _logger = logger;
            _requestFormatter = requestLogFormatter;
            _operationContext = operationContext;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            var context = _operationContext.Context;

            _logger.LogInformation(_requestFormatter.FormatStarted(context));

            var response = await next();

            _logger.LogInformation(_requestFormatter.FormatCompleted(context));

            return response;
        }

    }
}
