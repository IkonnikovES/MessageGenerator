using MediatR;
using MessageGenerator.Api.Hubs;
using MessageGenerator.Domain.Models;
using MessageGenerator.Domain.Notifications;
using MessageGenerator.Entities.Domains;
using MessageGenerator.Services.Queries;
using Microsoft.AspNetCore.SignalR;
using System.Threading;
using System.Threading.Tasks;

namespace MessageGenerator.Api.NotificationHandlers
{
    public class AddMessageNotificationHandler : INotificationHandler<ApplyMessageNotification>
    {
        private readonly IMediator mediator;
        private readonly IHubContext<MessageHub> hubContext;

        public AddMessageNotificationHandler(IMediator mediator, IHubContext<MessageHub> hubContext)
        {
            this.mediator = mediator;
            this.hubContext = hubContext;
        }

        public async Task Handle(ApplyMessageNotification notification, CancellationToken cancellationToken)
        {
            var messageId = notification.MessageModel.Id;

            var query = new GetQuery<Message, ChatMessageModel>(messageId);
            var message = await mediator.Send(query, cancellationToken);

            await hubContext.Clients.All.SendAsync(nameof(MessageHub.SendMessage), message, cancellationToken);
        }
    }
}
