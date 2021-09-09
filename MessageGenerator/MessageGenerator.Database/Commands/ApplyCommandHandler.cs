using AutoMapper;
using MediatR;
using MessageGenerator.Database.DataAccess;
using MessageGenerator.Domain.Commands;
using MessageGenerator.Domain.Conventions.Abstractions;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MessageGenerator.Database.Commands
{
    public class ApplyCommandHandler<TEntity, TModel> : IRequestHandler<ApplyCommand<TEntity, TModel>>
        where TEntity : IEntity
        where TModel : IHasKey<long>
    {
        private readonly IMapper mapper;

        public ApplyCommandHandler(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public Task<Unit> Handle(ApplyCommand<TEntity, TModel> request, CancellationToken cancellationToken)
        {
            TEntity entity;
            var model = request.Model;

            if (model.Id == 0)
            {
                entity = Create(model);
            }
            else
            {
                entity = ApplicationDbContext<TEntity>.Data.FirstOrDefault(x => x.Id == model.Id);
                if (entity != null)
                {
                    mapper.Map(model, entity);
                }
                else
                {
                    entity = Create(model);
                }
            }

            mapper.Map(entity, model);

            return Unit.Task;
        }

        private TEntity Create(TModel model)
        {
            var entity = mapper.Map<TEntity>(model);
            if (entity is ICreatable creatable)
            {
                creatable.CreatedAt = DateTimeOffset.Now;
            }

            entity.Id = ApplicationDbContext<TEntity>.Data.Count + 1;

            ApplicationDbContext<TEntity>.Data.Add(entity);

            return entity;
        }
    }
}
