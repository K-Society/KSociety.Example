using KSociety.Base.App.Utility.Dto.Req;
using ProtoBuf;

namespace KSociety.Example.App.Dto.Req.ModifyField
{
    [ProtoContract]
    public class Book : ModifyFieldReq
    {
        public Book()
        {

        }

        public Book(Guid id, string fieldName, string value)
            : base(id, fieldName, value)
        {

        }
    }
}
