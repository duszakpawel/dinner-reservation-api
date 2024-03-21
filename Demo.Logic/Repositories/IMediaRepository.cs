using Demo.Logic.Infrastructure;
using Demo.Logic.Models.Entities;

namespace Demo.Logic.Repositories
{
    public interface IMediaRepository : IRepository
    {
        Task<int> InsertMediaAsync(Media media);
        Task<int> UpdateMediaAsync(Media media);
        Task<IEnumerable<Media>> GetMediaAsync();
        Task<IEnumerable<Media>> GetMediaAsync(ISearchCriteria<Media> searchCriteria);
    }
}
