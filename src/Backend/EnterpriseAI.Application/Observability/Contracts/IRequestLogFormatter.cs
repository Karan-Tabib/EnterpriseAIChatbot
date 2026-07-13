using EnterpriseAI.Application.FailureManagement.Models;
using EnterpriseAI.Application.Observability.Context;

namespace EnterpriseAI.Application.Observability.Contracts
{
    public interface IRequestLogFormatter
    {
        string FormatStarted(OperationContext context);

        string FormatCompleted(OperationContext context);

        string FormatFailed(OperationContext context);
    }

    public interface IPerformanceLogFormatter
    {
        string Format(
            OperationContext context,
            long elapsedMilliseconds,
            bool isSlowRequest);
    }
    public interface IFailureLogFormatter
    {
        string Format(
            OperationContext context,
            FailureDecision decision,
            Exception exception);
    }
    public interface ITransactionLogFormatter
    {
        string Started(OperationContext context);

        string Committed(OperationContext context);

        string RolledBack(OperationContext context);
    }

}
