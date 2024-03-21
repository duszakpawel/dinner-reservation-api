using Microsoft.AspNetCore.Http;

namespace Demo.Logic.Seedwork.Cqrs.CommandHandlers
{
    public interface ICommandHandler<in TCommand>
        where TCommand : ICommand
    {
        Task HandleAsync(HttpContext context, TCommand command);
    }
}
