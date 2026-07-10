using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseAI.Application.Conversations.GetConversation
{
    public sealed class GetConversationResult
    {
        public Guid ConversationId { get; init; }

        public string Title { get; init; } = string.Empty;

        public DateTime CreatedOn { get; init; }
    }
}
