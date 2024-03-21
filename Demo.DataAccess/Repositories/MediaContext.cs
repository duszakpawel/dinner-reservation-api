using Demo.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.DataAccess.Repositories
{
    public class MediaContext : DbContext
    {
        public MediaContext()
        {
        }

        public MediaContext(DbContextOptions<MediaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DbMedia> Media { get; set; }
        public virtual DbSet<DbAuthor> Authors { get; set; }
    }
}
