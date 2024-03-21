namespace Demo.Logic.Seedwork.Cqrs.OperationHandlers
{
    public interface IOperation { }

    public interface IOperation<out TResult> : IOperation { }
}
