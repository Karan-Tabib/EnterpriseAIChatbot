using EnterpriseAI.Application.Abstractions.Persistence.Repositories;
using EnterpriseAI.Application.Conversations.SendMessage;
using MediatR;

namespace EnterpriseAI.Application.Conversations.DeleteConversation
{
    public class DeleteConversationHandler : IRequestHandler<DeleteConversationCommand, DeleteConversationResult>
    {
        private readonly IConversationRepository _conversationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteConversationHandler(IConversationRepository conversationRepository,
            IUnitOfWork unitOfWork)
        {
            _conversationRepository = conversationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteConversationResult> Handle(DeleteConversationCommand request, CancellationToken cancellationToken)
        {
            var conversation = await _conversationRepository.DeleteConversation(
               request.ConversationId,
               cancellationToken);

            if (conversation is null)
                throw new KeyNotFoundException("Conversation not be Deleted.");


            await _unitOfWork.CommitAsync(cancellationToken);


            return new DeleteConversationResult
            {
                ConversationId = conversation.Id,
            };
        }
    }
}
