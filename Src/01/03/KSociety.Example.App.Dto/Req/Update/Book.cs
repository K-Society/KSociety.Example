using KSociety.Base.App.Shared;
using ProtoBuf;

namespace KSociety.Example.App.Dto.Req.Update
{
    [ProtoContract]
    public class Book : IRequest
    {
        [ProtoMember(1), CompatibilityLevel(CompatibilityLevel.Level200)]
        public Guid Id { get; set; }

        [ProtoMember(2)]
        public string Title { get; set; }

        [ProtoMember(3)]
        public string AuthorName { get; set; }

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
