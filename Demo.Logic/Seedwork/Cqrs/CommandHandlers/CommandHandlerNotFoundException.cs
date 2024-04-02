﻿namespace Demo.Logic.Seedwork.Cqrs.CommandHandlers
{
    public class CommandHandlerNotFoundException : Exception
    {
        public Type CommandType { get; }

        public CommandHandlerNotFoundException(Type commandType)
            : base($"Cannot find handler for command {commandType.Name}.")
        {
            CommandType = commandType;
        }
    }
}
