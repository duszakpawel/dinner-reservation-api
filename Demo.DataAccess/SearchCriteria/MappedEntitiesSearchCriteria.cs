using Demo.Logic.Infrastructure;
using Demo.Logic.Seedwork.Ddd;

namespace Demo.DataAccess.SearchCriteria
{
    internal abstract class MappedEntitiesSearchCriteria<TDomainEntity, TDbEntity> : ISearchCriteria<TDomainEntity> where TDomainEntity : IAggregateRoot
    {
        public abstract IQueryable<TDbEntity> Apply(IQueryable<TDbEntity> entities);

        public List<ISearchCriteria<TDomainEntity>> OtherCriteria { get; } = new List<ISearchCriteria<TDomainEntity>>();

        public ISearchCriteria<TDomainEntity> And(ISearchCriteria<TDomainEntity> otherCriteria)
        {
            OtherCriteria.Add(otherCriteria);
            return this;
        }
    }
}
