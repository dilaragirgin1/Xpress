using System.Linq.Expressions;
using BG.Express.API.Model.Request;

namespace BG.Express.API.Data.Extensions;
public static class QueryableExtensions
{
    public static IQueryable<T> WhereIf<T>(this IQueryable<T> queryable, Expression<Func<T, bool>> filter, bool condition)
    {
        if (condition)
            return queryable.Where(filter);

        return queryable;
    }

    public static IQueryable<T> PaginateWith<T>(this IQueryable<T> queryable, PagedBaseRequest request)
    {
        if (request.Offset is not null && request.Limit is not null)
        {
            return queryable.Skip(request.Offset.Value).Take(request.Limit.Value);
        }

        return queryable;
    }
}
