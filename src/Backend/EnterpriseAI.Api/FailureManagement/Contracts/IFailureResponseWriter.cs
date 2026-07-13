using EnterpriseAI.Application.FailureManagement.Models;

namespace EnterpriseAI.Api.FailureManagement.Contracts
{
    public interface IFailureResponseWriter
    {
        Task WriteAsync(
            HttpContext httpContext,
            FailureDecision failureResult,
            CancellationToken cancellationToken);
    }

}
