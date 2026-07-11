using MediatR;

namespace EnterpriseAI.Application.Conversations.DeleteConversation
{
    public class DeleteConversationCommand :IRequest<DeleteConversationResult>
    {
        public Guid ConversationId { get; set; }
        public DeleteConversationCommand(Guid id)
        {
            ConversationId = id;
        }
    }
}
