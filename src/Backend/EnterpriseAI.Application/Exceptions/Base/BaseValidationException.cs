using EnterpriseAI.Application.FailureManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace EnterpriseAI.Application.Exceptions.Base
{
    public class BaseValidationException : BaseException
    {
        //public override int StatusCode => StatusCodes.Status404NotFound;
        public override string ErrorCode => "resource.not_found";
        public override LogLevel LogLevel => LogLevel.Information;
        public override FailureCategory Category => FailureCategory.Validation;
        public BaseValidationException(string message)
            : base(message)
        {
        }
    }
}
