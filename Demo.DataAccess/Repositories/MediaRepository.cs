using Demo.DataAccess.Models;
using Demo.Logic.Infrastructure;
using Demo.Logic.Models.Entities;
using Demo.Logic.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Demo.DataAccess.Models.Extensions;
using Demo.DataAccess.SearchCriteria;

namespace Demo.DataAccess.Repositories
{
    internal class MediaRepository : BaseRepository, IMediaRepository
    {
        private readonly MediaContext _context;
        private readonly ILogger<MediaRepository> _logger;

        public MediaRepository(MediaContext context, ILogger<MediaRepository> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger;
        }

        public async Task<IEnumerable<Media>> GetMediaAsync()
        {
            return await GetMediaQuery()
                .Select(media => media.ToModel())
                .ToListAsync();
        }

        public async Task<IEnumerable<Media>> GetMediaAsync(ISearchCriteria<Media> searchCriteria)
        {
            return await GetMediaQuery()
                .Apply(searchCriteria)
                .Select(media => media.ToModel())
                .ToListAsync();
        }

        public async Task<int> InsertMediaAsync(Media media)
        {
            var dbMedia = media.ToDb();
            _context.Media.Add(dbMedia);
            await _context.SaveChangesAsync();

            return dbMedia.Id;
        }

        public Task<int> UpdateMediaAsync(Media media)
        {
            throw new NotImplementedException();
        }

        private IQueryable<DbMedia> GetMediaQuery()
        {
            return _context.Media.Include(media => media.Authors);
        }
    }
}
