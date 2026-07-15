using EnterpriseAI.Application.AI.Models;
using EnterpriseAI.Domain;

namespace EnterpriseAI.Application.AI.Prompting
{
    public sealed class PromptBuilder : IPromptBuilder
    {
        private readonly ISystemPromptProvider _systemPromptProvider;

        public PromptBuilder(ISystemPromptProvider systemPromptProvider)
        {
            _systemPromptProvider = systemPromptProvider;
        }
        public AppChatRequest Build(Conversation conversation)
        {
            var messages = new List<AppChatMessage>();

            AddSystemPrompt(messages);
            AddConversationHistory(messages, conversation);

            //AddConversationSummary()

            //AddRetrievedDocuments()

            //AddCurrentMessage()
            return new AppChatRequest
            {
                Messages = messages
            };
        }

        private void AddConversationHistory(List<AppChatMessage> messages, Conversation conversation)
        {

            // Conversation history
            foreach (var message in conversation.Messages)
            {
                messages.Add(new AppChatMessage
                {
                    Role = MapRole(message.Role),
                    Content = message.Content
                });
            }
        }

        private void AddSystemPrompt(List<AppChatMessage> messages)
        {
            // System prompt
            messages.Add(new AppChatMessage
            {
                Role = AppChatRole.System,
                Content = "You are a helpful AI assistant."
            });
        }


        private static AppChatRole MapRole(MessageRole role)
        {
            return role switch
            {
                MessageRole.User => AppChatRole.User,
                MessageRole.Assistant => AppChatRole.Assistant,
                MessageRole.System => AppChatRole.System,
                _ => throw new InvalidOperationException($"Unsupported role {role}")
            };
        }

        
    }
}
