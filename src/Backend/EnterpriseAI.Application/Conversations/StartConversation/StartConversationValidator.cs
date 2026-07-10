using FluentValidation;

namespace EnterpriseAI.Application.Conversations.StartConversation
{
    public class StartConversationValidator :AbstractValidator<StartConversationCommand>
    {

        public StartConversationValidator()
        {

        }

        public bool Validate(StartConversationCommand command)
        {
           
            return true;
        }
    }
}
