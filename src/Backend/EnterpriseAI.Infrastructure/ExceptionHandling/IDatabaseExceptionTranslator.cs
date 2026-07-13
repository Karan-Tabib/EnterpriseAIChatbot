namespace EnterpriseAI.Infrastructure.ExceptionHandling
{
    public interface IDatabaseExceptionTranslator
    {
        Exception Translate(Exception exception);
    }
}
