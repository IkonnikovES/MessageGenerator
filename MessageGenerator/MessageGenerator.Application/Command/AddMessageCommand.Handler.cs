using MediatR;
using MessageGenerator.Domain.Commands;
using MessageGenerator.Domain.Models;
using MessageGenerator.Domain.Notifications;
using MessageGenerator.Entities.Domains;
using System.Threading;
using System.Threading.Tasks;

namespace MessageGenerator.Application.Command
{
    public class AddMessageCommandHandler : IRequestHandler<AddMessageCommand>
    {
        private readonly IMediator mediator;

        public AddMessageCommandHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public Task<Unit> Handle(AddMessageCommand request, CancellationToken cancellationToken)
        {
            var model = request.Model;

            var transactionCommand = new TransactionCommand();

            var command = new ApplyCommand<Message, MessageModel>(model);
            var notification = new ApplyMessageNotification(model);

            transactionCommand.AddCommand(command, notification);

            return mediator.Send(transactionCommand, cancellationToken);
        }
    }
}
