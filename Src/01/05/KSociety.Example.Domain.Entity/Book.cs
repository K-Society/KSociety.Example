namespace KSociety.Example.Domain.Entity
{
    public class Book : Base.Domain.Shared.Class.Entity
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string AuthorName { get; private set; }

        public Book()
        {

        }

        public Book(Guid id, string title, string authorName)
        {
            Id = id;
            Title = title;
            AuthorName = authorName;
        }
    }
}
