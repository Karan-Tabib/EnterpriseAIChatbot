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
        public ChatRequest Build(Conversation conversation)
        {
            var messages = new List<ChatMessage>();

            AddSystemPrompt(messages);
            AddConversationHistory(messages, conversation);

            //AddConversationSummary()

            //AddRetrievedDocuments()

            //AddCurrentMessage()
            return new ChatRequest
            {
                Messages = messages
            };
        }

        private void AddConversationHistory(List<ChatMessage> messages, Conversation conversation)
        {

            // Conversation history
            foreach (var message in conversation.Messages)
            {
                messages.Add(new ChatMessage
                {
                    Role = MapRole(message.Role),
                    Content = message.Content
                });
            }
        }

        private void AddSystemPrompt(List<ChatMessage> messages)
        {
            // System prompt
            messages.Add(new ChatMessage
            {
                Role = ChatRole.System,
                Content = "You are a helpful AI assistant."
            });
        }


        private static ChatRole MapRole(MessageRole role)
        {
            return role switch
            {
                MessageRole.User => ChatRole.User,
                MessageRole.Assistant => ChatRole.Assistant,
                MessageRole.System => ChatRole.System,
                _ => throw new InvalidOperationException($"Unsupported role {role}")
            };
        }

        
    }
}
