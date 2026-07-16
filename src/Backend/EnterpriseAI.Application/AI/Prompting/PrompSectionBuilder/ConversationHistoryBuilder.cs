using EnterpriseAI.Application.AI.Models;
using EnterpriseAI.Domain.Conversations;

namespace EnterpriseAI.Application.AI.Prompting.PrompSectionBuilder
{
    public class ConversationHistoryBuilder : IPromptSectionBuilder
    {
        public ConversationHistoryBuilder()
        {

        }
        public void Build(
            MemoryContext context,
            List<AppChatMessage> prompt)
        {
            if (context.Messages == null || context.Messages.Count == 0)
                return;

            foreach (var message in context.Messages)
            {
                prompt.Add(new AppChatMessage
                {
                    Role = PromptBuilder.MapRole(message.Role),
                    Content = message.Content
                });
            }
        }

    }
}
