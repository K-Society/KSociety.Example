using KSociety.Base.App.Utility.Dto.Req;
using ProtoBuf;

namespace KSociety.Example.App.Dto.Req.Remove
{
    [ProtoContract]
    public class Book : RemoveReq
    {
        public Book()
        {

        }

        public Book(Guid id)
            : base(id)
        {

        }
    }
}
