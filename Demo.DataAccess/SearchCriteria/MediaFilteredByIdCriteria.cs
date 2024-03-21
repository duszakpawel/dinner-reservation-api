using Demo.DataAccess.Models;
using Demo.Logic.Models.Entities;
using Demo.Logic.Repositories;

namespace Demo.DataAccess.SearchCriteria
{
    internal class MediaFilteredByIdCriteria : MappedEntitiesSearchCriteria<Media, DbMedia>, IMediaFilteredByIdCriteria
    {
        public int Id { get; set; }

        public override IQueryable<DbMedia> Apply(IQueryable<DbMedia> entities)
        {
            if (Id == default)
            {
                throw new ArgumentException($"{nameof(Id)} is not provided.");
            }

            return entities.Where(media => media.Id == Id);
        }
    }
}
