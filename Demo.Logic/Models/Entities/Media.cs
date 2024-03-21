using Demo.Contracts;
using Demo.Logic.Seedwork.Ddd;

namespace Demo.Logic.Models.Entities
{
    public class Media(int id, string name, string description, MediaType mediaType, IEnumerable<Author> authors) : IAggregateRoot
    {
        private readonly List<Author> _authors = authors.ToList() ?? [];

        public int Id { get; } = id;
        public string Name { get; private set; } = name;
        public MediaType MediaType { get; private set; } = mediaType;
        public string Description { get; private set; } = description;
        public IEnumerable<Author> Authors => _authors.AsReadOnly();

        public bool IsActivelyCreated()
        {
            return _authors.Any(author => (DateTime.Today - author.LastContribution).Days < 30);
        }

        public static Media FromDb(int id, string name, string description, MediaType mediaType, IEnumerable<Author> authors)
        {
            return new Media(id, name, description, mediaType, authors);
        }

        public void Update(CreateOrUpdateMedia update)
        {
            Name = update.Name;
            Description = update.Description;
            MediaType = update.MediaType;

            UpdateAuthors(update.Authors);
            EnsureValidState();
        }

        private void UpdateAuthors(IEnumerable<Contracts.Author> authors)
        {
            _authors.Clear();
            _authors.AddRange(authors.Select(author => new Author(author.Name,author.LastContribution)).ToList());
        }

        private void EnsureValidState()
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(Name))
            {
                errors.Add("Invalid name.");
            }

            if (string.IsNullOrWhiteSpace(Description))
            {
                errors.Add("Invalid description.");
            }

            if (!Authors.Any())
            {
                errors.Add("No authors.");

                if (Authors.Any(x => string.IsNullOrWhiteSpace(x.Name)))
                {
                    errors.Add("Invalid authors.");
                }
            }

            if (errors.Any())
            {
                throw new InvalidEntityStateException(errors);
            }
        }
    }
}
