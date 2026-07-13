using EnterpriseAI.Application.FailureManagement.Models;
using EnterpriseAI.Application.FailureManagement.Contracts;
using EnterpriseAI.Application.Exceptions.Base;

namespace EnterpriseAI.Application.FailureManagement.Strategies
{
    public class BusinessFailureStrategy : IFailureStrategy
    {
        public Type ExceptionType => typeof(BaseBusinessException);

        public bool CanHandle(FailureContext context)
        {
            throw new NotImplementedException();
        }

        public Task<FailureDecision> ExecuteAsync(FailureContext context, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

