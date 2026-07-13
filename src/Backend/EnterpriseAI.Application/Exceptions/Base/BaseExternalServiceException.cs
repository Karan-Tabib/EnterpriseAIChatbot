using EnterpriseAI.Application.FailureManagement.Models;
using Microsoft.Extensions.Logging;

namespace EnterpriseAI.Application.Exceptions.Base
{
    public sealed class BaseExternalServiceException : BaseException
    {
        public override string ErrorCode => "externalservice.exception";
        public override LogLevel LogLevel => LogLevel.Information;

        public override FailureCategory Category => FailureCategory.ExternalService;

        public BaseExternalServiceException(string message) : base(message)
        {

        }
    }


}
