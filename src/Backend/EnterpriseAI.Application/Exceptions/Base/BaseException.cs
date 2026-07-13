using EnterpriseAI.Application.FailureManagement.Models;
using Microsoft.Extensions.Logging;

namespace EnterpriseAI.Application.Exceptions.Base
{
    public abstract class BaseException : Exception
    {
        public abstract string ErrorCode { get; }
        public abstract LogLevel LogLevel { get; }
        public BaseException(string message) : base(message)
        {

        }
        public virtual string Title => Message;
        public abstract FailureCategory Category { get; }
        public virtual bool IsRecoverable => false;
    }
}
