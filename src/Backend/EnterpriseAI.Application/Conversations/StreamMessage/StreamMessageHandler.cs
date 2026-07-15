
using EnterpriseAI.Application.AI;
using EnterpriseAI.Application.AI.Contracts;
using EnterpriseAI.Application.AI.Models;
using MediatR;

namespace EnterpriseAI.Application.Conversations.StreamMessage
{
    public class StreamMessageHandler : IRequestHandler<StreamMessageCommand, IAsyncEnumerable<AppChatChunk>>
    {
        private readonly IAIOrchestrator _AIOrchestrator;

        public StreamMessageHandler(IAIOrchestrator aiOrchestrator)
        {
            _AIOrchestrator = aiOrchestrator;
        }
        public Task<IAsyncEnumerable<AppChatChunk>> Handle(StreamMessageCommand request, CancellationToken cancellationToken)
        {

            var stream = _AIOrchestrator.StreamResponseAsync(
                request.ConversationId,
                request.Message,
                cancellationToken);

            return Task.FromResult(stream);
        }
    }
}
