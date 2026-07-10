using EnterpriseAI.Application.Abstractions.Persistence.Repositories;
using MediatR;

using EnterpriseAI.Domain;
namespace EnterpriseAI.Application.Conversations.StartConversation
{
    public sealed class StartConversationHandler : IRequestHandler<StartConversationCommand, StartConversationResult>
    {
        private readonly IConversationRepository _conversationRepository;
        private readonly IUnitOfWork _unitOfWork;
        public StartConversationHandler(
            IConversationRepository conversationRepository,
            IUnitOfWork unitOfWork)
        {
            _conversationRepository = conversationRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<StartConversationResult> Handle(StartConversationCommand command, CancellationToken cancellationToken)
        {

            var conversation = Conversation.Create();


            await _conversationRepository.AddAsync(conversation, cancellationToken);

            await _unitOfWork.CommitAsync(cancellationToken);

            return new StartConversationResult
            {
                ConversationId = conversation.Id,
                Title = conversation.Title,
                CreatedOn = conversation.CreatedOn
            };
        }
    }
}
