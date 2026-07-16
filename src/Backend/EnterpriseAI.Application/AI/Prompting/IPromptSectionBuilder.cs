using EnterpriseAI.Application.AI.Models;
using EnterpriseAI.Domain.Conversations;

namespace EnterpriseAI.Application.AI.Prompting
{
    public interface IPromptSectionBuilder
    {
        void Build(
            MemoryContext context,
            List<AppChatMessage> prompt);
    }
}
