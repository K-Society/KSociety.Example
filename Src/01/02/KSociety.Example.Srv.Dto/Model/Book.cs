using KSociety.Base.InfraSub.Shared.Interface;
using ProtoBuf;

namespace KSociety.Example.Srv.Dto.Model
{
    [ProtoContract]
    public class Book : IObject
    {
        [ProtoMember(1)] 
        public Dto.Book BookDto { get; set; }

        public Book()
        {
        }

        public Book(
            Dto.Book book
        )
        {
            BookDto = book;
        }
    }
}
