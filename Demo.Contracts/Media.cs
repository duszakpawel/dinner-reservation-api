namespace Demo.Contracts
{
    public class Media
    {
        public MediaType MediaType { get; set; }
        public int Id { get; set; }

        public string Description { get; set; }
        public string Name { get; set; }
        public IEnumerable<Author> Authors { get; set; }
    }
}
