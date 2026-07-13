using Confluent.Kafka;
using EnterpriseAI.Application.Observability.Context.ContextPropagation.Contracts;

namespace EnterpriseAI.Application.Observability.Context.ContextPropagation.Kafka
{
    public sealed class KafkaOperationContextExporter
     : IOperationContextExporter<Headers>
    {
        public void Export(
            OperationContext context,
            Headers headers)
        {
            throw new NotImplementedException();
        }
    }

}
