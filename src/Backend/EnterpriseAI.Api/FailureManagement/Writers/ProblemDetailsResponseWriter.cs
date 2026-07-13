using EnterpriseAI.Api.FailureManagement.Contracts;
using EnterpriseAI.Application.FailureManagement.Models;

namespace EnterpriseAI.Api.FailureManagement.Writers
{
    public sealed class ProblemDetailsResponseWriter
    : IFailureResponseWriter
    {
        private readonly IFailureResponseMapper _mapper;

        public ProblemDetailsResponseWriter(IFailureResponseMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task WriteAsync(HttpContext context, FailureDecision failure, CancellationToken cancellationToken)
        {
            var problem = _mapper.Map(context, failure);

            context.Response.StatusCode = problem.Status!.Value;

            await context.Response.WriteAsJsonAsync(problem, cancellationToken);
        }
    }
}
