using MediatR;
using MessageGenerator.Domain.Commands;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MessageGenerator.Database.Commands
{
    public class TransactionCommandHandler : IRequestHandler<TransactionCommand>
    {
        private readonly ILogger<TransactionCommand> logger;
        private readonly IMediator mediator;

        public TransactionCommandHandler(ILogger<TransactionCommand> logger, IMediator mediator)
        {
            this.logger = logger;
            this.mediator = mediator;
        }

        public async Task<Unit> Handle(TransactionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                foreach (var (command, notification) in request.Commands)
                {
                    await mediator.Send(command, cancellationToken);
                    if (notification != null)
                    {
                        await mediator.Publish(notification, cancellationToken);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
            }

            return Unit.Value;
        }
    }
}
