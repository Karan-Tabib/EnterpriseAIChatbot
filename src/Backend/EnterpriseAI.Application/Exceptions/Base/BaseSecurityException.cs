using EnterpriseAI.Application.FailureManagement.Models;
using Microsoft.Extensions.Logging;

namespace EnterpriseAI.Application.Exceptions.Base
{
    public sealed class BaseSecurityException : BaseException
    {
        //public override int StatusCode => StatusCodes.Status404NotFound;
        public override string ErrorCode => "timeout";
        public override LogLevel LogLevel => LogLevel.Information;
        public override FailureCategory Category => FailureCategory.Timeout;
        public BaseSecurityException(string message)
            : base(message)
        {
        }
    }
}
