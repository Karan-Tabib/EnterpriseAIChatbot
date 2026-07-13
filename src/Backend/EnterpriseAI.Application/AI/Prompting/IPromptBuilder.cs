using EnterpriseAI.Application.AI.Models;

namespace EnterpriseAI.Application.AI.Prompting
{
    public interface IPromptBuilder
    {
        ChatRequest Build(
            IEnumerable<ChatMessage> history,
            string userMessage);
    }
}
