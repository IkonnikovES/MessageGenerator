using AutoMapper;
using MediatR;
using MessageGenerator.Database.DataAccess;
using MessageGenerator.Domain.Conventions.Abstractions;
using MessageGenerator.Services.Queries;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MessageGenerator.Database.Queries
{
    public class GetQueryHandler<TEntity, TModel> : IRequestHandler<GetQuery<TEntity, TModel>, TModel>
        where TEntity : IEntity
        where TModel : class
    {
        private readonly IMapper mapper;

        public GetQueryHandler(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public Task<TModel> Handle(GetQuery<TEntity, TModel> request, CancellationToken cancellationToken)
        {
            var entity = ApplicationDbContext<TEntity>.Data.FirstOrDefault(x => x.Id == request.Id);
            if (typeof(TEntity) != typeof(TModel))
            {
                return Task.FromResult(mapper.Map<TModel>(entity));
            }

            return Task.FromResult(entity as TModel);
        }
    }
}
