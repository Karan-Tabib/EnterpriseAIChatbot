using EnterpriseAI.Application.Exceptions.Base;
using EnterpriseAI.Application.Exceptions.Conversions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseAI.Infrastructure.ExceptionHandling
{
    public sealed class SqlServerExceptionTranslator : IDatabaseExceptionTranslator
    {
        public Exception Translate(Exception exception)
        {
            if (exception is InvalidOperationException &&
                exception.InnerException is SqlException sqlException1)
            {
                return TranslateSqlException(sqlException1);
            }
            switch (exception)
            {
                //case DbUpdateConcurrencyException ex:
                //    return new BaseInfrastructureException(
                //        "The data was modified by another process.",
                //        ex);

                case DbUpdateException ex
                    when ex.InnerException is SqlException sqlException:
                    return TranslateSqlException(sqlException);

                case SqlException sqlException:
                    return TranslateSqlException(sqlException);

                case TimeoutException ex:
                    return new InfrastructureTimeoutException(
                        "Database operation timed out.",
                        ex);

                default:
                    return exception;
            }
        }

        private static Exception TranslateSqlException(SqlException exception)
        {
            return exception.Number switch
            {
                //2627 => new DuplicateResourceException(
                //            "Resource already exists.", exception),

                //2601 => new DuplicateResourceException(
                //            "Duplicate key.", exception),

                //547 => new BaseBusinessException(
                //            "Referenced record does not exist.", exception),

                //1205 => new BaseInfrastructureException(
                //            "Database deadlock detected.", exception),
                4060 => new BaseInfrastructureException($"Database login failed :{exception.Message}"),
                -2 => new InfrastructureTimeoutException(
                            "Database timeout.", exception),

                //_ => new BaseInfrastructureException(
                //            "Database failure.", exception)
            };
        }
    }
}
