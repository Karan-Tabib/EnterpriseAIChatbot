
using EnterpriseAI.Application.Abstractions.Persistence.Repositories;
using EnterpriseAI.Application.Conversations.StartConversation;
using MediatR;

namespace EnterpriseAI.Application.Conversations.SendMessage
{
    public sealed class SendMessageHandler : IRequestHandler<SendMessageCommand, SendMessageResult>
    {
        private readonly IConversationRepository _conversationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SendMessageHandler(
            IConversationRepository conversationRepository,
        IUnitOfWork unitOfWork)
        {
            _conversationRepository = conversationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<SendMessageResult> Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            var conversation = await _conversationRepository.GetConversationWithMessages(
                request.ConversationId,
                cancellationToken);

            if (conversation is null)
                throw new KeyNotFoundException("Conversation not found.");

            conversation.AddUserMessage(request.Content);

            await _unitOfWork.CommitAsync(cancellationToken);

            var message = conversation.Messages.Last();

            return new SendMessageResult
            {
                ConversationId = conversation.Id,
                MessageId = message.Id,
                MessageContent = message.Content,
                CreatedAt = message.CreatedOn
            };
        }
    }

}
