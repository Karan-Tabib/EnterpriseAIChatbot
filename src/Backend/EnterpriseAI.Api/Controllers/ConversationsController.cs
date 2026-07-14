using EnterpriseAI.Application.Conversations.DeleteConversation;
using EnterpriseAI.Application.Conversations.GetConversation;
using EnterpriseAI.Application.Conversations.GetConversationMessages;
using EnterpriseAI.Application.Conversations.RenameConversation;
using EnterpriseAI.Application.Conversations.SendMessage;
using EnterpriseAI.Application.Conversations.StartConversation;
using EnterpriseAI.Application.AI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseAI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversationsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ConversationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateConversation(CancellationToken token)
        {
            // Logic to create a new conversation

            var result = await _mediator.Send(new StartConversationCommand(), token);

            return CreatedAtAction(nameof(GetConversation), new { id = result.ConversationId }, result);

        }


        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetConversation(Guid id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetConversationQuery(id), cancellationToken);

            return Ok(result);
        }

        [HttpPost("{conversationId:guid}/messages")]
        public async Task<IActionResult> SendMessage(Guid conversationId, [FromBody] ChatRequestDTO request, CancellationToken token)
        {
            // Logic to create a new Message

            var result = await _mediator.Send(new SendMessageCommand(conversationId, request.Content), token);

            return Ok(result);

        }


        [HttpGet("{conversationId:guid}/messages")]
        public async Task<IActionResult> GetMessages(Guid conversationId, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetConversationMessagesQuery(conversationId), cancellationToken);

            return Ok(result);
        }


        [HttpPut("{conversationId:guid}/rename/{title}")]
        public async Task<IActionResult> RenameTitle(Guid conversationId, string title,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new RenameConversationCommand(conversationId, title), cancellationToken);
            return Ok(result);
        }

        [HttpDelete("{conversationId:guid}")]
        public async Task<IActionResult> DeleteConversation(Guid conversationId, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteConversationCommand(conversationId));

            return NoContent();
        }



    }
}
