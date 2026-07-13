using EnterpriseAI.Application.Observability.Context;
using EnterpriseAI.Application.Observability.Contracts;

namespace EnterpriseAI.Application.Observability.Logging.Formatters
{
    public sealed class TransactionLogFormatter
     : ITransactionLogFormatter
    {
        public string Started(OperationContext context)
            => $"Transaction Started ({context.CorrelationId})";

        public string Committed(OperationContext context)
            => $"Transaction Committed ({context.CorrelationId})";

        public string RolledBack(OperationContext context)
            => $"Transaction Rolled Back ({context.CorrelationId})";
    }

}
