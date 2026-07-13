using EnterpriseAI.Application.FailureManagement.Models;
using EnterpriseAI.Application.Observability.Context;
using EnterpriseAI.Application.Observability.Contracts;

namespace EnterpriseAI.Application.Observability.Logging.Formatters
{

    public sealed class FailureLogFormatter
    : IFailureLogFormatter
    {
        public string Format(
            OperationContext context,
            FailureDecision decision,
            Exception exception)
        {
            return
                    $"""
                ==========================================================
                Failure
                ----------------------------------------------------------
                TraceId        : {context.TraceId}
                CorrelationId  : {context.CorrelationId}
                Request        : {context.RequestName}

                Category       : {decision.Category}
                Severity       : {decision.Severity}
                Recoverable    : {decision.Recoverable}
                RecoveryAction : {decision.RecoveryAction}

                Exception      : {exception.GetType().Name}

                Message        : {exception.Message}
                ==========================================================
                """;
        }
    }

}
