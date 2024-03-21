using Demo.Logic.Models.Entities;

namespace Demo.DataAccess.Models.Extensions
{
    internal static class Mediaxtensions
    {
        public static Media ToModel(this DbMedia media)
        {
            return Media.FromDb(media.Id, media.Name, media.Description, media.MediaType, media.Authors.Select(author => Author.FromDb(author.Name, author.LastContribution)));
        }

        /// <param name="dbQueueBeforeUpdate">ID istniejących relacji z junction tables są przepisywane z tego obiektu</param>
		public static DbMedia ToDb(this Media media)
        {
            var dbMedia = new DbMedia
            {
                Id = media.Id,
                Description = media.Description,
                MediaType = media.MediaType,
                Name = media.Name,
                Authors = media.Authors.Select(author => new DbAuthor
                {
                    Name = author.Name,
                    LastContribution = author.LastContribution
                }).ToList()
            };

            return dbMedia;
        }
    }
}
