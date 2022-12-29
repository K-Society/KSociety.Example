using KSociety.Base.App.Shared;
using ProtoBuf;

namespace KSociety.Example.App.Dto.Res.Remove
{
    [ProtoContract]
    public class Book : IResponse
    {
        [ProtoMember(1)]
        public bool Result { get; set; }

        public Book()
        {

        }

        public Book(bool result)
        {
            Result = result;
        }
    }
}
