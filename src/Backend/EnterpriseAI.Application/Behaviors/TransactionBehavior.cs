using EnterpriseAI.Application.Observability.Context;
using EnterpriseAI.Application.Observability.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseAI.Application.Behaviors
{
    public class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly ILogger<TransactionBehavior<TRequest, TResponse>> _logger;
        private readonly IOperationContextAccessor _operationContext;
        private readonly ITransactionLogFormatter _transactionLogFormatter;

        public TransactionBehavior(
            ILogger<TransactionBehavior<TRequest, TResponse>> logger,
            IOperationContextAccessor operationContext,
            ITransactionLogFormatter transactionLogFormatter)
        {
            _logger = logger;
            _transactionLogFormatter = transactionLogFormatter;
            _operationContext = operationContext;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = _operationContext.Context;
            _logger.LogInformation(_transactionLogFormatter.Started(context));
            var response = await next();
            _logger.LogInformation(_transactionLogFormatter.Committed(context));
            return response;
        }
    }
}
