
using MediatR;
using Microsoft.Extensions.Logging;

namespace EnterpriseAI.Application.Behaviors
{
    public sealed class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            Console.WriteLine("Logging - Before");
            _logger.LogInformation(
             "Executing {Request}",
            typeof(TRequest).Name);

            var response = await next();


            _logger.LogInformation(
           "Completed {Request}",
           typeof(TRequest).Name);

            Console.WriteLine("Logging - After");

            return response;
        }
    }
}
