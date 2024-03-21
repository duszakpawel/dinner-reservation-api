using Demo.Logic.Infrastructure;
using Demo.Logic.Models.Entities;
using Demo.Logic.Seedwork.Cqrs.QueryHandlers;

namespace Demo.Logic.Queries
{
    public class GetMediaQuery : IQuery<IEnumerable<Media>>
    {
        public GetMediaQuery()
        {
        }

        public GetMediaQuery(ISearchCriteria<Media> searchCriteria)
        {
            SearchCriteria = searchCriteria;
        }

        public ISearchCriteria<Media> SearchCriteria { get; }
    }
}
