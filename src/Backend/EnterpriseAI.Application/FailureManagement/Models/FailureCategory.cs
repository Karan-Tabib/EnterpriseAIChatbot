namespace EnterpriseAI.Application.FailureManagement.Models
{
    public enum FailureCategory
    {
        /*
         * FailureCategory

           ├── Validation
           ├── Business
           ├── Infrastructure
           ├── Security
           ├── Concurrency
           ├── Timeout
           ├── ExternalService
           ├── Unknown
           ├──
         */

        Validation,
        Business,
        Infrastructure,
        Security,
        Concurrency,
        Timeout,
        ExternalService,
        Unknown,
        NotFound,
    }
}
