namespace Demo.Contracts
{
    public class CreateOrUpdateMedia
    {
        public MediaType MediaType { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public IEnumerable<Author> Authors { get; set; }
    }
}
