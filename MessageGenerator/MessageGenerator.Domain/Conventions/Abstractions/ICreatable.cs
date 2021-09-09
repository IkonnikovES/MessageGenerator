using System;

namespace MessageGenerator.Domain.Conventions.Abstractions
{
    public interface ICreatable
    {
        DateTimeOffset CreatedAt { get; set; }
    }
}
