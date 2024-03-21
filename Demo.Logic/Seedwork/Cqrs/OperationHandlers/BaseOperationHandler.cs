using Microsoft.AspNetCore.Http;

namespace Demo.Logic.Seedwork.Cqrs.OperationHandlers
{
    public abstract class BaseOperationHandler<TOperation, TResult> : IOperationHandler<TOperation, TResult> where TOperation : IOperation<TResult>
    {
        public async Task<TResult> ExecuteAsync(HttpContext context, TOperation operation)
        {
            if (operation == null)
            {
                throw new ArgumentNullException(nameof(operation));
            }

            return await HandleInvoke(context, operation);
        }

        protected abstract Task<TResult> HandleInvoke(HttpContext context, TOperation operation);
    }
}
