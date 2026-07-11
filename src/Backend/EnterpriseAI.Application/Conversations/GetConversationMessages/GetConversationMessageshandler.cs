using EnterpriseAI.Application.Abstractions.Persistence.Repositories;
using EnterpriseAI.Application.Conversations.GetConversation;
using EnterpriseAI.Domain;
using MediatR;

namespace EnterpriseAI.Application.Conversations.GetConversationMessages
{
    public class GetConversationMessageshandler :
        IRequestHandler<GetConversationMessagesQuery, List<GetConversationMessagesResult>>
    {
        private readonly IConversationQueryRepository _conversationQueryRepository;

        public GetConversationMessageshandler(IConversationQueryRepository conversationMsgRepository)
        {
            _conversationQueryRepository = conversationMsgRepository;

        }
        public async Task<List<GetConversationMessagesResult>> Handle(GetConversationMessagesQuery request,
            CancellationToken cancellationToken)
        {
            var messages = await _conversationQueryRepository.GetMessagesAsync(
              request.ConversationId,
              cancellationToken);

            if (messages is null)
            {
                throw new KeyNotFoundException(
                    $"Conversation Messages for Id:'{request.ConversationId}' was not found.");
            }

            var result = new List<GetConversationMessagesResult>();
            
            foreach (var message in messages)
            {
                result.Add(
                new GetConversationMessagesResult
                {
                    ConversationId = request.ConversationId,
                    Id = message.Id,
                    Content = message.Content,
                    Role = message.Role,
                    CreatedOn = message.CreatedOn
                });
            }
            return result;   
        }
    }
}
