using Microsoft.AspNetCore.Http;

namespace Demo.Logic.Seedwork.Cqrs.QueryHandlers
{
    public abstract class BaseQueryHandler<TQuery, TResult> : IQueryHandler<TQuery, TResult>
            where TQuery : IQuery<TResult>
    {
        public async Task<TResult> ExecuteAsync(HttpContext context, TQuery query)
        {
            if(query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            return await HandleInvoke(context, query);
        }

        protected abstract Task<TResult> HandleInvoke(HttpContext context, TQuery query);
    }
}
