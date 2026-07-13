using EnterpriseAI.Application.Exceptions.Base;

namespace EnterpriseAI.Application.Exceptions.Conversions
{
    public class InfrastructureTimeoutException : BaseTimeoutException
    {
        public InfrastructureTimeoutException(string msg, Exception ex)
            : base(msg)
        {
        }
    }
}
