using FluentValidation;

namespace EnterpriseAI.Application.Conversations.RenameConversation
{
    public class RenameConversationValidator : AbstractValidator<RenameConversationCommand>
    {
        public RenameConversationValidator()
        {
            RuleFor(x => x.ConversationId).NotEmpty();
            RuleFor(x => x.NewTitle).NotEmpty();
                
        }
    }
}
