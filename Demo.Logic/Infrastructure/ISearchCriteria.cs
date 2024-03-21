using Demo.Logic.Seedwork.Ddd;

namespace Demo.Logic.Infrastructure
{
    public interface ISearchCriteria
    {
    }

    public interface ISearchCriteria<T> : ISearchCriteria where T : IAggregateRoot
    {
        ISearchCriteria<T> And(ISearchCriteria<T> otherCriteria);
    }
}
