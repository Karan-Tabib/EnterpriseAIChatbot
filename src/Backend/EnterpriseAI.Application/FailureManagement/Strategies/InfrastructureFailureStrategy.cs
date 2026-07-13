using EnterpriseAI.Application.FailureManagement.Models;
using EnterpriseAI.Application.FailureManagement.Contracts;
using EnterpriseAI.Application.Exceptions.Base;

namespace EnterpriseAI.Application.FailureManagement.Strategies
{
    public class InfrastructureFailureStrategy : IFailureStrategy
    {
        public Type ExceptionType => typeof(BaseInfrastructureException);

        public Task<FailureDecision> ExecuteAsync(FailureContext context, CancellationToken cancellationToken)
        {
            var exception = (BaseInfrastructureException)context.Exception;

            var failure = new FailureDecision
            {
                //StatusCode = StatusCodes.Status400BadRequest,

                Title = "Infrastructure failure",

                ErrorCode = "INFRASTRUCTURE_ERROR",

                Detail = exception.Message,

                Category = FailureCategory.Infrastructure,

                Severity = FailureSeverity.Warning,

                RecoveryAction = RecoveryAction.None,

                IsRecoverable = false
            };

            return Task.FromResult(failure);
        }
    }
}

