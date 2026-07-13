using EnterpriseAI.Application.FailureManagement.Models;

namespace EnterpriseAI.Application.FailureManagement.Contracts
{
    public interface IFailureStrategyResolver
    {
        IFailureStrategy Resolve(FailureContext context);
    }
}
