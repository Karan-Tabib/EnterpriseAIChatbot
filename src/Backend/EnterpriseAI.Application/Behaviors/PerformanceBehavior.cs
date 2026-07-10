

using MediatR;
using System.Diagnostics;

namespace EnterpriseAI.Application.Behaviors
{
    public class PerformanceBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var sw = Stopwatch.StartNew();

            Console.WriteLine("Performance - Start");

            var response = await next();

            sw.Stop();

            Console.WriteLine($"Performance - {sw.ElapsedMilliseconds} ms");

            return response;
        }
    }
}
