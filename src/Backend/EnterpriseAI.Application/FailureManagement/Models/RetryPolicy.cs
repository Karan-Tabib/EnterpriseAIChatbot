namespace EnterpriseAI.Application.FailureManagement.Models
{
    public enum RetryPolicy
    {
        NoRetry,
        ImmediateRetry,
        ExponentialRetry,
        LinearRetry,
        CircuitBreaker,
        Fallback,
        DeadLetter,
    }
}
