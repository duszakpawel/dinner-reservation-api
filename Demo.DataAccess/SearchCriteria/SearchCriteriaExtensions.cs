using Demo.Logic.Infrastructure;
using Demo.Logic.Seedwork.Ddd;

namespace Demo.DataAccess.SearchCriteria
{
    internal static class SearchCriteriaExtensions
    {
        public static IQueryable<TDbEntity> Apply<TDomainEntity, TDbEntity>(this IQueryable<TDbEntity> entities, ISearchCriteria<TDomainEntity> searchCriteria) where TDomainEntity : IAggregateRoot
        {
            if (searchCriteria == null)
            {
                return entities;
            }

            var mappedSearchCriteria = (MappedEntitiesSearchCriteria<TDomainEntity, TDbEntity>)searchCriteria;
            var applied = mappedSearchCriteria.Apply(entities);

            foreach (var otherCriteria in mappedSearchCriteria.OtherCriteria)
            {
                applied = applied.Apply(otherCriteria);
            }

            return applied;
        }
    }
}
