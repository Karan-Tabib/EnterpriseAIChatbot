using EnterpriseAI.Application.FailureManagement.Models;
using EnterpriseAI.Application.FailureManagement.Contracts;
using EnterpriseAI.Application.FailureManagement.Strategies;


namespace EnterpriseAI.Application.FailureManagement.Resolver
{

    public sealed class FailureStrategyResolver : IFailureStrategyResolver
    {
        private readonly Dictionary<Type, IFailureStrategy> _strategies;
        private readonly IUnknownFailureStrategy _unknownStrategy;

        public FailureStrategyResolver(IEnumerable<IFailureStrategy> strategies,
                IUnknownFailureStrategy unknownStrategy)
        {
            _strategies = strategies.ToDictionary(s => s.ExceptionType);
            _unknownStrategy = unknownStrategy;
        }

        public IFailureStrategy Resolve(FailureContext context)
        {
            var exceptionType = context.Exception.GetType();

            // Walk the inheritance hierarchy
            while (exceptionType != null)
            {
                if (_strategies.TryGetValue(exceptionType, out var strategy))
                {
                    return strategy;
                }
                exceptionType = exceptionType.BaseType;
            }

            return _unknownStrategy;
        }
    }
}
