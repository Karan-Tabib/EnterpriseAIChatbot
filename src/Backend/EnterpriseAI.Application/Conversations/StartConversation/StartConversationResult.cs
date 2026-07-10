using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseAI.Application.Conversations.StartConversation
{
    public class StartConversationResult
    {
        public Guid ConversationId { get; set; } 
        public string Title { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }

    }
}
