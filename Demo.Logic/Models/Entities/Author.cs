namespace Demo.Logic.Models.Entities
{
    public class Author
    {
        public string Name { get; set; }
        public DateTime LastContribution { get; set; }

        public Author(string name, DateTime lastContribution)
        {
            Name = name;
            LastContribution = lastContribution;
        }

        public static Author FromDb(string name, DateTime lastContribution)
        {
            return new Author(name, lastContribution);
        }
    }
}
