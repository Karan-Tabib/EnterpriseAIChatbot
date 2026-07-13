using Confluent.Kafka;
using EnterpriseAI.Application.Observability.Context.ContextPropagation.Contracts;

namespace EnterpriseAI.Application.Observability.Context.ContextPropagation.Kafka
{
    public sealed class KafkaOperationContextImporter
        : IOperationContextImporter<Headers>
    {
        public OperationContext Import(Headers headers)
        {
            throw new NotImplementedException();
        }
    }

}
