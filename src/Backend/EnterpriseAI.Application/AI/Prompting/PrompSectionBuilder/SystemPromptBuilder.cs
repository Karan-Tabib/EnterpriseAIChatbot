using EnterpriseAI.Application.AI.Models;
using EnterpriseAI.Domain.Conversations;

namespace EnterpriseAI.Application.AI.Prompting.PrompSectionBuilder
{
    public class SystemPromptBuilder : IPromptSectionBuilder
    {
        private readonly ISystemPromptProvider _systemPromptProvider;
        public SystemPromptBuilder(ISystemPromptProvider systemPromptProvider)
        {
            _systemPromptProvider = systemPromptProvider;
        }
        public void Build(MemoryContext context, List<AppChatMessage> prompt)
        {
            var systemMessage = new AppChatMessage
            {
                Role = AppChatRole.System,
                Content = _systemPromptProvider.GetPrompt()
            };
            prompt.Add(systemMessage);
        }
    }
}
