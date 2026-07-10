using MediatR;

namespace EnterpriseAI.Application.Conversations.StartConversation
{
    public class StartConversationCommand :IRequest<StartConversationResult>
    {

        public StartConversationCommand()
        {

        }
    }
}
