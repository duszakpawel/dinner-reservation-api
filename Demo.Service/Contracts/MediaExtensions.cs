using Demo.Contracts;

namespace Demo.Service.Contracts
{
    public static class MediaExtensions
    {
        public static Media ToContract(this Logic.Models.Entities.Media media)
        {
            return new Media
            {
                Name = media.Name,
                Authors = media.Authors.Select(x => new Author 
                {
                    Name = x.Name,
                    LastContribution = x.LastContribution
                }),
                Description = media.Description,
                Id = media.Id,
                MediaType = media.MediaType
            };
        }
    }
}
