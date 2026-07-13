using EnterpriseAI.Application.Exceptions.Base;

namespace EnterpriseAI.Application.Exceptions.Conversions
{
    public sealed class ConversationNotFoundException : BaseResourceNotFoundException
    {
        public ConversationNotFoundException(Guid conversationId)
            : base($"Conversation '{conversationId}' was not found.")
        {
        }
    }
}
