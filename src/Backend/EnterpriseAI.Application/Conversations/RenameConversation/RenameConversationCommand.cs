using MediatR;

namespace EnterpriseAI.Application.Conversations.RenameConversation
{
    public class RenameConversationCommand : IRequest<RenameConversationResult>
    {
        public Guid ConversationId { get; set; }
        public string NewTitle { get; set; } = string.Empty;

        public RenameConversationCommand(Guid conversationId, string newTitle)
        {
            ConversationId = conversationId;
            NewTitle = newTitle;
        }
    }
}
