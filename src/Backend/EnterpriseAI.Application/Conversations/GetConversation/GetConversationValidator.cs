using FluentValidation;


namespace EnterpriseAI.Application.Conversations.GetConversation
{
    public sealed class GetConversationValidator : AbstractValidator<GetConversationQuery>
    {
        public GetConversationValidator()
        {
            RuleFor(x => x.ConversationId).NotEmpty();
        }
    }
}
