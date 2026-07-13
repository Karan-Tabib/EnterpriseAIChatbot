using EnterpriseAI.Application.Abstractions.Persistence.Repositories;
using EnterpriseAI.Infrastructure.ExceptionHandling;
using EnterpriseAI.Infrastructure.Persistence.Context;


namespace EnterpriseAI.Infrastructure.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private readonly IDatabaseExceptionTranslator _exceptionTranslator;
        public UnitOfWork(AppDbContext dbContext, IDatabaseExceptionTranslator exceptionTranslator)
        {
            _dbContext = dbContext;
            _exceptionTranslator = exceptionTranslator;
        }
        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await _dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().FullName);

                if (ex.InnerException != null)
                {
                    Console.WriteLine(ex.InnerException.GetType().Name);
                }
                throw _exceptionTranslator.Translate(ex);
            }
        }
    }
}
