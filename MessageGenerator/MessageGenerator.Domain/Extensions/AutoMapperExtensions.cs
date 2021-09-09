using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace MessageGenerator.Domain.Extensions
{
    public static class AutoMapperExtensions
    {
        public static IQueryable<TDestination> ProjectToIf<TSource, TDestination>(this IQueryable<TSource> query, IConfigurationProvider configuration, bool predicate)
        {
            if (predicate)
            {
                return query.ProjectTo<TDestination>(configuration);
            }
            return query.Cast<TDestination>();
        }

        public static IMappingExpression<TSource, TDestination> ForMemberFrom<TSource, TDestination, TMember>(this IMappingExpression<TSource, TDestination> expression,
            Expression<Func<TDestination, TMember>> uExpression, Expression<Func<TSource, TMember>> tExpression)
        {
            return expression.ForMember(uExpression, y => y.MapFrom(tExpression));
        }

        public static void IgnoreOtherMembers<TSource, TDestination>(this IMappingExpression<TSource, TDestination> mappingExpression)
        {
            mappingExpression.ForAllOtherMembers(x => x.Ignore());
        }
    }
}
