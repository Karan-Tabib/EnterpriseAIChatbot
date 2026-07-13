using EnterpriseAI.Application.FailureManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace EnterpriseAI.Application.Exceptions.Base
{
    public sealed class BaseInfrastructureException : BaseException
    {
        //public override int StatusCode => StatusCodes.Status404NotFound;
        public override string ErrorCode => "Infrastructure.error";
        public override LogLevel LogLevel => LogLevel.Information;
        public override FailureCategory Category => FailureCategory.Infrastructure;
        public BaseInfrastructureException(string message) : base(message)
        {

        }
    }


}
