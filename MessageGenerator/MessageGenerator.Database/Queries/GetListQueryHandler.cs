using AutoMapper;
using MediatR;
using MessageGenerator.Database.DataAccess;
using MessageGenerator.Domain.Conventions.Abstractions;
using MessageGenerator.Services.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MessageGenerator.Database.Queries
{
    public class GetListQueryHandler<TEntity, TModel> : IRequestHandler<GetListQuery<TEntity, TModel>, List<TModel>> where TEntity : IEntity
    {
        private readonly IMapper mapper;

        public GetListQueryHandler(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public Task<List<TModel>> Handle(GetListQuery<TEntity, TModel> request, CancellationToken cancellationToken)
        {
            var items = ApplicationDbContext<TEntity>.Data;
            if (typeof(TEntity) != typeof(TModel))
            {
                return Task.FromResult(mapper.Map<List<TModel>>(items));
            }

            return Task.FromResult(items.Cast<TModel>().ToList());
        }
    }
}
