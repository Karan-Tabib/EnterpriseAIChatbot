using EnterpriseAI.Application.Abstractions.Persistence.Repositories;
using EnterpriseAI.Application.AI.Contracts;
using EnterpriseAI.Application.AI.Models;
using EnterpriseAI.Application.AI.Prompting;
using EnterpriseAI.Application.Exceptions.Conversions;
using System.Text;

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

        public async Task<AppChatResponse> GenerateResponseAsync(Guid conversationId, string userMessage, CancellationToken cancellationToken)
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

            return new AppChatResponse
            {
                Content = assistantMessage.Content,
                //MessageId = assistantMessage.Id,
                //CreatedAt = assistantMessage.CreatedOn
            };
        }

        public async IAsyncEnumerable<AppChatChunk> StreamResponseAsync(Guid conversationId, string userMessage, CancellationToken cancellationToken)
        {
            // Load conversation
            var conversation = await _conversationRepository.GetConversationWithMessages(conversationId, cancellationToken);

            if (conversation is null)
                throw new ConversationNotFoundException(conversationId);

            // Store user message
            conversation.AddUserMessage(userMessage);
            await _unitOfWork.CommitAsync(cancellationToken);


            // Build prompt
            var chatRequest = _promptBuilder.Build(conversation);

            
            // Ask AI
            var builder = new StringBuilder();

            await foreach (var chunk in _chatService.StreamAsync(chatRequest, cancellationToken))
            {
                builder.Append(chunk.Content);

                yield return chunk;
            }

            // Stream finished

            // Store assistant response
            var assistantMessage = conversation.AddAssistantMessage(builder.ToString());

            // Persist everything
            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}