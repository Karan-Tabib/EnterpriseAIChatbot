using EnterpriseAI.Application.Abstractions.Persistence.Repositories;
using MediatR;

namespace EnterpriseAI.Application.Conversations.GetConversation
{
    public class GetConversationHandler : IRequestHandler<GetConversationQuery, GetConversationResult>
    {
        private readonly IConversationQueryRepository _conversationQueryRepository;

        public GetConversationHandler(
            IConversationQueryRepository conversationRepository)
        {
            _conversationQueryRepository = conversationRepository;
        }
        public async Task<GetConversationResult> Handle(GetConversationQuery request, CancellationToken cancellationToken)
        {
            var conversation = await _conversationQueryRepository.GetByIdAsync(
              request.ConversationId,
              cancellationToken);

            if (conversation is null)
            {
                throw new KeyNotFoundException(
                    $"Conversation '{request.ConversationId}' was not found.");
            }

            return new GetConversationResult
            {
                ConversationId = conversation.Id,
                Title = conversation.Title,
                CreatedOn = conversation.CreatedOn
            };
        }
    }
}
