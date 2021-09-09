using MessageGenerator.Domain.Conventions.Abstractions;
using System;

namespace MessageGenerator.Domain.Models
{
    public class ChatMessageModel : ICreatable
    {
        public string Text { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}
