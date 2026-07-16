using EnterpriseAI.Application.AI.Models;
using EnterpriseAI.Domain.Conversations;

namespace EnterpriseAI.Application.AI.Prompting
{
    public interface IPromptBuilder
    {
        AppChatRequest Build(MemoryContext memory);
    }

    public interface ISystemPromptProvider
    {
        string GetPrompt();
    }
}
