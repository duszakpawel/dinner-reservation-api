namespace Demo.Logic.Seedwork.Cqrs.QueryHandlers
{
    public interface IQuery { }

    public interface IQuery<out TResult> : IQuery { }
}
