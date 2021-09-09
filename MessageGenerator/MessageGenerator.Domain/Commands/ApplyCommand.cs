using MediatR;
using MessageGenerator.Domain.Conventions.Abstractions;

namespace MessageGenerator.Domain.Commands
{
    public class ApplyCommand<TEntity, TModel> : IRequest
        where TEntity : IEntity
        where TModel : IHasKey<long>
    {
        public ApplyCommand(TModel model)
        {
            Model = model;
        }

        public TModel Model { get; }
    }
}
