using MediatR;
using MessageGenerator.Domain.Conventions.Abstractions;

namespace MessageGenerator.Services.Queries
{
    public class GetQuery<TEntity, TModel> : IRequest<TModel> where TEntity : IEntity
    {
        public GetQuery(long id)
        {
            Id = id;
        }

        public long Id { get; }
    }
}
