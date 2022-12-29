using KSociety.Base.App.Shared;
using ProtoBuf;

namespace KSociety.Example.App.Dto.Req.Copy
{
    [ProtoContract]
    public class Book : IRequest
    {
        [ProtoMember(1)]
        public string Title { get; set; }

        [ProtoMember(2)]
        public string AuthorName { get; set; }

        public Book()
        {

        }

        public Book(string title, string authorName)
        {
            Title = title;
            AuthorName = authorName;
        }
    }
}
