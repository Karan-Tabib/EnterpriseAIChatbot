using EnterpriseAI.Application.Exceptions.Base;

namespace EnterpriseAI.Application.Exceptions.Conversions
{
    public sealed class ConversationNotDeletedException : BaseResourceNotFoundException
    {
        public ConversationNotDeletedException(Guid conversationId)
            : base($"Conversation '{conversationId}'  record not found .Can not  be deleted.")
        {
        }
    }
}
