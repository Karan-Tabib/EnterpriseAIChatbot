
using EnterpriseAI.Application.Abstractions.Persistence.Repositories;
using EnterpriseAI.Application.AI.Contracts;
using EnterpriseAI.Application.AI.Models;
using EnterpriseAI.Application.Conversations.StartConversation;
using MediatR;

namespace EnterpriseAI.Application.Conversations.SendMessage
{
    public sealed class SendMessageHandler : IRequestHandler<SendMessageCommand, SendMessageResult>
    {
        private readonly IAIOrchestrator _AIOrchestrator;

        public SendMessageHandler(
        IAIOrchestrator aiOrchestrator)
        {
            _AIOrchestrator = aiOrchestrator;
        }

        public async Task<SendMessageResult> Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            //var conversation = await _conversationRepository.GetConversationWithMessages(
            //    request.ConversationId,
            //    cancellationToken);

           
            ChatResponse response = await _AIOrchestrator.GenerateResponseAsync(request.ConversationId,
                    request.Message, cancellationToken);

            return new SendMessageResult
            {
                ConversationId = request.ConversationId,
                MessageId = response.MessageId,
                Response = response.Content,
                CreatedAt = response.CreatedAt
            };
        }
    }

}
