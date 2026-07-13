using EnterpriseAI.Application.FailureManagement.Models;

namespace EnterpriseAI.Application.FailureManagement.Contracts
{
    public interface IFailureStrategy
    {
        Type ExceptionType { get; }
        Task<FailureDecision> ExecuteAsync(FailureContext context, CancellationToken cancellationToken);
    }

    public interface IUnknownFailureStrategy: IFailureStrategy
    {

    }

    public interface IFailureClassifier { }
    
}
