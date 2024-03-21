namespace Demo.Logic.Seedwork.Cqrs.QueryHandlers
{
    public class QueryHandlerNotFoundException : Exception
    {
        public Type QueryType { get; }

        public QueryHandlerNotFoundException(Type queryType)
            : base($"Cannot find handler for query {queryType.Name}.")
        {
            QueryType = queryType;
        }
    }

}
