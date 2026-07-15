using FluentValidation;
namespace EnterpriseAI.Application.Conversations.StreamMessage
{
    public class StreamMessageValidator: AbstractValidator<StreamMessageCommand>
    {
        public StreamMessageValidator()
        {
            RuleFor(x => x.ConversationId).NotEmpty();
            RuleFor(x => x.Message).NotEmpty().WithMessage("Message content cannot be empty.");
        }
    }
}
