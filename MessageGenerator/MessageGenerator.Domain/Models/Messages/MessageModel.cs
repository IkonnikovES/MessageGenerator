using MessageGenerator.Domain.Conventions.Abstractions;

namespace MessageGenerator.Domain.Models
{
    public class MessageModel : ApplyModel
    {
        public MessageModel()
        {

        }

        public MessageModel(string text)
        {
            Text = text;
        }

        public string Text { get; set; }
    }
}
