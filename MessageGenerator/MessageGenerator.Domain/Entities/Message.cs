using MessageGenerator.Domain.Conventions.Abstractions;
using System;

namespace MessageGenerator.Entities.Domains
{
    public class Message : Entity, ICreatable
    {
        public string Text { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}
