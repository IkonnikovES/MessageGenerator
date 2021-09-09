namespace MessageGenerator.Domain.Conventions.Abstractions
{
    public interface IHasKey<TKey>
    {
        TKey Id { get; set; }
    }
}
