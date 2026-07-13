using EnterpriseAI.Application.Observability.Context;
using EnterpriseAI.Application.Observability.Contracts;

namespace EnterpriseAI.Application.Observability.Logging.Formatters
{
    public sealed class PerformanceLogFormatter
     : IPerformanceLogFormatter
    {
        public string Format(
            OperationContext context,
            long elapsedMilliseconds,
            bool isSlowRequest)
        {
            return
                $"""
                ==========================================================
                Performance
                ----------------------------------------------------------
                TraceId        : {context.TraceId}
                CorrelationId  : {context.CorrelationId}
                Request        : {context.RequestName}
                Duration       : {elapsedMilliseconds} ms
                Slow Request   : {isSlowRequest}
                ==========================================================
                """;
        }
    }
}
