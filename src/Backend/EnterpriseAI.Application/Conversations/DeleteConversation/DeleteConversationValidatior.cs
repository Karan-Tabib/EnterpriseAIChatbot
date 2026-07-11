using FluentValidation;

namespace EnterpriseAI.Application.Conversations.DeleteConversation
{
    public class DeleteConversationValidatior :AbstractValidator<DeleteConversationCommand>
    {
        public DeleteConversationValidatior()
        {
            RuleFor(x => x.ConversationId).NotEmpty();
        }
    }
}
