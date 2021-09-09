using MediatR;
using System.Collections.Generic;

namespace MessageGenerator.Services.Queries
{
    public class GetListQuery<TEntity, TModel> : IRequest<List<TModel>>
    {
    }
}
