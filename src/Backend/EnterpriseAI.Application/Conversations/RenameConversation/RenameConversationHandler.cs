using EnterpriseAI.Application.Abstractions.Persistence.Repositories;
using EnterpriseAI.Application.Conversations.SendMessage;
using MediatR;

namespace EnterpriseAI.Application.Conversations.RenameConversation
{
    public class RenameConversationHandler : IRequestHandler<RenameConversationCommand, RenameConversationResult>
    {
        private readonly IConversationRepository _conversationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RenameConversationHandler(IConversationRepository conversationRepository,
            IUnitOfWork unitOfWork)
        {
            _conversationRepository = conversationRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<RenameConversationResult> Handle(RenameConversationCommand request, CancellationToken cancellationToken)
        {
            var conversation = await _conversationRepository.GetConversationWithMessages(
               request.ConversationId,
               cancellationToken);

            if (conversation is null)
                throw new KeyNotFoundException("Conversation not found.");

            conversation.Rename(request.NewTitle);

            await _unitOfWork.CommitAsync(cancellationToken);


            return new RenameConversationResult
            {
                ConversationId = conversation.Id,
                Title = conversation.Title,
                CreatedOn = conversation.CreatedOn,
                UpdatedOn = conversation.UpdatedOn,
            };
        }
    }
}
