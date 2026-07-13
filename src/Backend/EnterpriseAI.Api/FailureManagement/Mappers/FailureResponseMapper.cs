using EnterpriseAI.Api.FailureManagement.Contracts;
using EnterpriseAI.Application.FailureManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseAI.Api.FailureManagement.Mappers
{
    public sealed class FailureResponseMapper : IFailureResponseMapper
    {
        public ProblemDetails Map(
            HttpContext httpContext,
            FailureDecision failure)
        {
            var statusCode = failure.Category switch
            {
                FailureCategory.Validation => StatusCodes.Status400BadRequest,

                FailureCategory.Business => StatusCodes.Status409Conflict,

                FailureCategory.Security => StatusCodes.Status401Unauthorized,

                FailureCategory.NotFound => StatusCodes.Status404NotFound,

                FailureCategory.Timeout => StatusCodes.Status408RequestTimeout,

                FailureCategory.Infrastructure => StatusCodes.Status503ServiceUnavailable,

                FailureCategory.Unknown => StatusCodes.Status500InternalServerError,

                _ => StatusCodes.Status500InternalServerError
            };

            var problem = new ProblemDetails
            {
                Status = statusCode,
                Title = failure.Title,
                Detail = failure.Detail,
                Instance = httpContext.Request.Path
            };

            problem.Extensions["traceId"] = httpContext.TraceIdentifier;

            problem.Extensions["errorCode"] = failure.ErrorCode;

             problem.Extensions["category"] = failure.Category.ToString();

            problem.Extensions["severity"] = failure.Severity.ToString();

            problem.Extensions["recoverable"] = failure.IsRecoverable;

            problem.Extensions["recoveryAction"] = failure.RecoveryAction.ToString();

            foreach (var extension in failure.Extensions)
            {
                problem.Extensions[extension.Key] = extension.Value;
            }

            return problem;
        }
    }

}
