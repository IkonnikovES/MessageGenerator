namespace MessageGenerator.Domain.Conventions.Abstractions
{
    public class ApplyModel : IHasKey<long>
    {
        public long Id { get; set; }
    }
}
