﻿using Microsoft.AspNetCore.Http;

namespace Demo.Logic.Seedwork.Cqrs.OperationHandlers
{
    public interface IOperationHandler<in TOperation, TResult>
        where TOperation : IOperation<TResult>
    {
        public Task<TResult> ExecuteAsync(HttpContext context, TOperation operation);
    }
}
