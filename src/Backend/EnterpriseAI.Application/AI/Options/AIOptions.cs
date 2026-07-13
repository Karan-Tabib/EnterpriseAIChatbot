using EnterpriseAI.Application.AI.Providers;

namespace EnterpriseAI.Application.AI.Options
{
    public sealed class AIOptions
    {
        public AIProvider Provider { get; init; }

        public string Model { get; init; } = string.Empty;

        public double Temperature { get; init; } = 0.2;

        public int MaxTokens { get; init; } = 4000;
    }
}
