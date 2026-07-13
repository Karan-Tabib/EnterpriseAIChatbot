namespace EnterpriseAI.Application.FailureManagement.Models
{
    public enum RecoveryAction
    {
        /*
         * 
         * 
         * None
           Retry
           Fallback
           CircuitBreaker
           QueueForLater
           Restart
           Escalate
            */

        None,
        Retry,
        Fallback,
        CircuitBreaker,
        QueueForLater,
        Restart,
        Escalate,
    }
}
