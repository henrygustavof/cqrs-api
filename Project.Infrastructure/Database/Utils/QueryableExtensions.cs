using System;
using System.Linq;
using System.Linq.Expressions;

namespace Project.Infrastructure.Database.Utils
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string sortBy, string sortDirection)
        {
            var expression = source.Expression;

            var parameter = Expression.Parameter(typeof(T), "x");
            var selector = Expression.PropertyOrField(parameter, sortBy);
            var method = string.Equals(sortDirection, "desc", StringComparison.OrdinalIgnoreCase)
                ? "OrderByDescending"
                : "OrderBy";
            expression = Expression.Call(typeof(Queryable), method,
                new[] { source.ElementType, selector.Type },
                expression, Expression.Quote(Expression.Lambda(selector, parameter)));

            return source.Provider.CreateQuery<T>(expression);
        }

        public static IQueryable<T> WhereIf<T>(
            this IQueryable<T> source, bool condition,
            Expression<Func<T, bool>> predicate)
        {
            return condition ? source.Where(predicate) : source;
        }
    }
}
