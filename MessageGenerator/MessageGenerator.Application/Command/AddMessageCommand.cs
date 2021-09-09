using MediatR;
using MessageGenerator.Domain.Models;

namespace MessageGenerator.Application.Command
{
    public class AddMessageCommand : IRequest
    {
        public AddMessageCommand(MessageModel model)
        {
            Model = model;
        }

        public MessageModel Model { get; }
    }
}
