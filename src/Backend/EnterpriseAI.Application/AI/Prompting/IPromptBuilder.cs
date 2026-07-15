using EnterpriseAI.Application.AI.Models;
using EnterpriseAI.Domain;

namespace EnterpriseAI.Application.AI.Prompting
{
    public interface IPromptBuilder
    {
        AppChatRequest Build(Conversation conversation);
    }

    public interface ISystemPromptProvider
    {
        string GetPrompt();
    }

    
}
