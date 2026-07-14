using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseAI.Application.AI.Prompting
{

    public sealed class DefaultSystemPromptProvider : ISystemPromptProvider
    {
        public string GetPrompt()
        {
            return """
               You are EnterpriseAI.

               You are a helpful AI assistant specializing in software engineering.

               Answer clearly and accurately.

               If you don't know the answer, say so instead of making one up.
               """;
        }
    }
}
