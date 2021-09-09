using MediatR;
using MessageGenerator.Domain.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MessageGenerator.Application.Command
{
    public class GenerateRandomMessageCommandHandler : IRequestHandler<GenerateRandomMessageCommand>
    {
        private readonly IMediator mediator;

        public GenerateRandomMessageCommandHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public Task<Unit> Handle(GenerateRandomMessageCommand request, CancellationToken cancellationToken)
        {
            var message = Guid.NewGuid().ToString("N");
            var model = new MessageModel(message);

            return mediator.Send(new AddMessageCommand(model), cancellationToken);
        }
    }
}
