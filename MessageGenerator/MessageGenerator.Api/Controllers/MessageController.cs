using MediatR;
using MessageGenerator.Domain.Models;
using MessageGenerator.Entities.Domains;
using MessageGenerator.Services.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MessageGenerator.Api.Controllers
{
    public class MessageController : ApplicationController
    {
        private readonly IMediator mediator;

        public MessageController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ChatMessageModel>>> Get(CancellationToken cancellationToken)
        {
            var query = new GetListQuery<Message, ChatMessageModel>();
            var result = await mediator.Send(query, cancellationToken);

            return Ok(result);
        }
    }
}
