using EnterpriseAI.Application.Observability.Context;
using EnterpriseAI.Application.Observability.Contracts;
using System.Text;

namespace EnterpriseAI.Application.Observability.Logging.Formatters;

public sealed class RequestLogFormatter : IRequestLogFormatter
{
    public string FormatStarted(OperationContext context)
    {
        var sb = CreateHeader("Request Started");

        Append(sb, "TraceId", context.TraceId);
        Append(sb, "SpanId", context.SpanId);
        Append(sb, "CorrelationId", context.CorrelationId);
        Append(sb, "RequestId", context.RequestId);

        sb.AppendLine();

        Append(sb, "Request", context.RequestName);
        Append(sb, "UserId", context.UserId);
        Append(sb, "TenantId", context.TenantId);

        sb.AppendLine();

        Append(sb, "Machine", Environment.MachineName);
        Append(sb, "Environment", Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"));

        sb.AppendLine();

        Append(sb, "Started", context.StartedOnUtc.ToString("O"));

        AppendFooter(sb);

        return sb.ToString();
    }

    public string FormatCompleted(OperationContext context)
    {
        var sb = CreateHeader("Request Completed");

        Append(sb, "TraceId", context.TraceId);
        Append(sb, "CorrelationId", context.CorrelationId);
        Append(sb, "Request", context.RequestName);
        Append(sb, "Status", "Success");

        AppendFooter(sb);

        return sb.ToString();
    }

    public string FormatFailed(OperationContext context)
    {
        var sb = CreateHeader("Request Failed");

        Append(sb, "TraceId", context.TraceId);
        Append(sb, "CorrelationId", context.CorrelationId);
        Append(sb, "Request", context.RequestName);
        Append(sb, "Status", "Failed");

        AppendFooter(sb);

        return sb.ToString();
    }

    private static StringBuilder CreateHeader(string title)
    {
        var sb = new StringBuilder();

        sb.AppendLine("==========================================================");
        sb.AppendLine(title);
        sb.AppendLine("----------------------------------------------------------");

        return sb;
    }

    private static void AppendFooter(StringBuilder sb)
    {
        sb.AppendLine("==========================================================");
    }

    private static void Append(StringBuilder sb, string name, string? value)
    {
        if (!string.IsNullOrWhiteSpace(value))
        {
            sb.AppendLine($"{name,-15}: {value}");
        }
    }
}