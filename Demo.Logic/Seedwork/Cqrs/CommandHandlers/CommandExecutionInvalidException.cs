namespace Demo.Logic.Seedwork.Cqrs.CommandHandlers
{
    public class CommandExecutionInvalidException : Exception
    {
        public int ErrorCode { get; private set; }

        public CommandExecutionInvalidException(int errorCode, string errorMessage, Exception? innerException = null)
            : base(errorMessage, innerException)
        {
            ErrorCode = errorCode;
        }
    }
}
