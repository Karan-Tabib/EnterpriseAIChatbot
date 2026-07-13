using EnterpriseAI.Application.FailureManagement.Models;
using EnterpriseAI.Application.FailureManagement.Contracts;

namespace EnterpriseAI.Application.FailureManagement.Strategies
{
    public class TimeoutFailureStrategy : IFailureStrategy
    {
        public Type ExceptionType => typeof(TimeoutException);

        public Task<FailureDecision> ExecuteAsync(FailureContext context, CancellationToken cancellationToken)
        {
            var exception = (TimeoutException)context.Exception;

            var failure = new FailureDecision
            {
                //StatusCode = StatusCodes.Status400BadRequest,

                Title = "Validation Failed",

                ErrorCode = "VALIDATION_ERROR",

                Detail = exception.Message,

                Category = FailureCategory.Validation,

                Severity = FailureSeverity.Warning,

                RecoveryAction = RecoveryAction.None,

                IsRecoverable = false
            };

            return Task.FromResult(failure);
        }
    }
}

