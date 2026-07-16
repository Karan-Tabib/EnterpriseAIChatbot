using EnterpriseAI.Application.AI.Models;
using EnterpriseAI.Domain;
using EnterpriseAI.Domain.Conversations;


namespace EnterpriseAI.Application.AI.Prompting
{
    public sealed class PromptBuilder : IPromptBuilder
    {
        private readonly IEnumerable<IPromptSectionBuilder> _builder;
        public PromptBuilder(IEnumerable<IPromptSectionBuilder> builder)
        {
            _builder = builder;
        }

        public AppChatRequest Build(MemoryContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            var prompt = new List<AppChatMessage>();

            foreach(var builder in _builder)
            {
                builder.Build(context, prompt);
            }

            // Future
            //AppendConversationHistory(prompt, context);
            //AppendSystemPrompt(prompt);
            // AppendConversationSummary(prompt, context);
            // AppendRetrievedDocuments(prompt, context);
            // AppendUserProfile(prompt, context);
            // AppendToolResults(prompt, context);



            return new AppChatRequest
            {
                Messages = prompt
            };
        }

       

        
        public static AppChatRole MapRole(MessageRole role)
        {
            return role switch
            {
                MessageRole.User => AppChatRole.User,
                MessageRole.Assistant => AppChatRole.Assistant,
                MessageRole.System => AppChatRole.System,
                _ => throw new InvalidOperationException($"Unsupported message role '{role}'.")
            };
        }
    }
}
