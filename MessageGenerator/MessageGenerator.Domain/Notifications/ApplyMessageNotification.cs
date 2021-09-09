using MediatR;
using MessageGenerator.Domain.Models;

namespace MessageGenerator.Domain.Notifications
{
    public class ApplyMessageNotification : INotification
    {
        public ApplyMessageNotification(MessageModel messageModel)
        {
            MessageModel = messageModel;
        }

        public MessageModel MessageModel { get; }
    }
}
