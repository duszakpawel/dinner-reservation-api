using Demo.Logic.Infrastructure;
using Demo.Logic.Models.Entities;

namespace Demo.Logic.Repositories
{
    public interface IMediaFilteredByIdCriteria : ISearchCriteria<Media>
    {
        int Id { get; set; }
    }
}
