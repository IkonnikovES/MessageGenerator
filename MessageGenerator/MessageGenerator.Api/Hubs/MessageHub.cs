using MessageGenerator.Domain.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MessageGenerator.Api.Hubs
{
    public class MessageHub : BaseHub
    {
        private readonly IHubContext<MessageHub> hubContext;

        public MessageHub(IHubContext<MessageHub> hubContext, ILogger<MessageHub> logger) : base(logger)
        {
            this.hubContext = hubContext;
        }

        public Task SendMessage(ChatMessageModel model)
        {
            return Clients.All.SendAsync(nameof(SendMessage), model);
        }
    }
}
