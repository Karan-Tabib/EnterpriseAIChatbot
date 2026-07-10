namespace EnterpriseAI.SharedKernel
{
    public class BaseEntity
    {
        public Guid Id { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime UpdatedOn { get; private set; }

    }
}