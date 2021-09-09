using MediatR;
using System.Collections.Generic;

namespace MessageGenerator.Domain.Commands
{
    public class TransactionCommand : IRequest
    {
        public TransactionCommand()
        {
            Commands = new List<(IBaseRequest, INotification)>();
        }

        public List<(IBaseRequest, INotification)> Commands { get; }

        public TransactionCommand AddCommand(IBaseRequest command, INotification notification)
        {
            Commands.Add((command, notification));
            return this;
        }

        public TransactionCommand AddCommand(IBaseRequest command)
        {
            return AddCommand(command, null);
        }
    }
}
