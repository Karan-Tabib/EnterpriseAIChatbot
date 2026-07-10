using EnterpriseAI.Application.Conversations.GetConversation;
using EnterpriseAI.Application.Conversations.StartConversation;
using EnterpriseAI.Contracts.Chat;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

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
    }
}
