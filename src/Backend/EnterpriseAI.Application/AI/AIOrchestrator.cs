using EnterpriseAI.Application.Abstractions.Persistence.Repositories;
using EnterpriseAI.Application.AI.Contracts;
using EnterpriseAI.Application.AI.Models;
using EnterpriseAI.Application.AI.Prompting;
using EnterpriseAI.Application.Exceptions.Conversions;

namespace EnterpriseAI.Application.AI
{
    public sealed class AIOrchestrator : IAIOrchestrator
    {
        private readonly IConversationRepository _conversationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPromptBuilder _promptBuilder;
        private readonly IChatService _chatService;

        public AIOrchestrator(
            IConversationRepository conversationRepository,
            IUnitOfWork unitOfWork,
            IPromptBuilder promptBuilder,
            IChatService chatService)
        {
            _conversationRepository = conversationRepository;
            _unitOfWork = unitOfWork;
            _promptBuilder = promptBuilder;
            _chatService = chatService;
        }

        public async Task<ChatResponse> GenerateResponseAsync(Guid conversationId, string userMessage, CancellationToken cancellationToken)
        {
            // Load conversation
            var conversation = await _conversationRepository.GetConversationWithMessages(conversationId, cancellationToken);

            if (conversation is null)
                throw new ConversationNotFoundException(conversationId);

            // Store user message
            conversation.AddUserMessage(userMessage);

            // Build prompt
            var chatRequest = _promptBuilder.Build(conversation);

            // Ask AI
            var chatResponse = await _chatService.SendAsync(chatRequest, cancellationToken);

            // Store assistant response
            var assistantMessage = conversation.AddAssistantMessage(chatResponse.Content);

            // Persist everything
            await _unitOfWork.CommitAsync(cancellationToken);

            return new ChatResponse
            {
                Content = assistantMessage.Content,
                MessageId = assistantMessage.Id,
                CreatedAt = assistantMessage.CreatedOn
            };
        }
    }
}