
using Demo.Contracts;

namespace Demo.DataAccess.Models
{
    public partial class DbMedia
    {
        public DbMedia()
        {
            Authors = [];
        }

        public MediaType MediaType { get; set; }
        public int Id { get; set; }

        public string Description { get; set; }
        public string Name { get; set; }
        public ICollection<DbAuthor> Authors { get; set; }
    }
}
