using Microsoft.AspNetCore.Http;

namespace Demo.Logic.Seedwork.Cqrs.QueryHandlers
{
    public interface IQueryHandler<in TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        Task<TResult> ExecuteAsync(HttpContext context, TQuery query);
    }
}
