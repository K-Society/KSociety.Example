using KSociety.Base.Srv.Dto;
using ProtoBuf;

namespace KSociety.Example.Srv.Dto.List
{
    [ProtoContract]
    public class Book : ObjectList<Dto.Book>
    {
        public Book() { }

        public Book(List<Dto.Book> books)
        {
            List = books;
        }
    }
}
