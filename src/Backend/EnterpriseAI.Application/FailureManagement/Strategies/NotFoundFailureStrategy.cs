using EnterpriseAI.Application.FailureManagement.Models;
using EnterpriseAI.Application.FailureManagement.Contracts;
using EnterpriseAI.Application.Exceptions.Base;

namespace EnterpriseAI.Application.FailureManagement.Strategies
{
    public class NotFoundFailureStrategy : IFailureStrategy
    {
        public Type ExceptionType => typeof(BaseResourceNotFoundException);

        public Task<FailureDecision> ExecuteAsync(FailureContext context, CancellationToken cancellationToken)
        {
            var exception = (BaseResourceNotFoundException)context.Exception;

            var failure = new FailureDecision
            {
                //StatusCode = StatusCodes.Status400BadRequest,

                Title = "Resource Not Found ",

                ErrorCode = "NOT_FOUND_ERROR",

                Detail = exception.Message,

                Category = FailureCategory.NotFound,

                Severity = FailureSeverity.Warning,

                RecoveryAction = RecoveryAction.None,

                IsRecoverable = false
            };

            return Task.FromResult(failure);
        }
    }
}

