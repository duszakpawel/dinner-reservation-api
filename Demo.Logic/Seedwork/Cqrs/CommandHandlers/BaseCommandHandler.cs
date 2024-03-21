using Microsoft.AspNetCore.Http;

namespace Demo.Logic.Seedwork.Cqrs.CommandHandlers
{
    public abstract class BaseCommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {
        public async Task HandleAsync(HttpContext context, TCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            await HandleInvoke(context, command);

            await Task.CompletedTask;
        }

        protected abstract Task HandleInvoke(HttpContext context, TCommand command);
    }
}
