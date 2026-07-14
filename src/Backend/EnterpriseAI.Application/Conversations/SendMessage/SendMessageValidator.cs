using EnterpriseAI.Application.Conversations.StartConversation;
using FluentValidation;

namespace EnterpriseAI.Application.Conversations.SendMessage
{
    public class SendMessageValidator : AbstractValidator<SendMessageCommand>
    {
        public SendMessageValidator()
        {
            RuleFor(x => x.ConversationId).NotEmpty();
            RuleFor(x => x.Message).NotEmpty().WithMessage("Message content cannot be empty.");
        }

    }

}
