namespace EnterpriseAI.Api.Exceptions
{
    public sealed record ExceptionDetails(
    int StatusCode,
    string Title,
    string ErrorCode,
    LogLevel LogLevel);
}
