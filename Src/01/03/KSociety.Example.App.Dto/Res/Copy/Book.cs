using KSociety.Base.App.Shared;
using KSociety.Base.InfraSub.Shared.Interface;
using ProtoBuf;

namespace KSociety.Example.App.Dto.Res.Copy
{
    [ProtoContract]
    public class Book : IResponse, IIdObject
    {
        [ProtoMember(1), CompatibilityLevel(CompatibilityLevel.Level200)]
        public Guid Id { get; set; }

        public Book()
        {

        }

        public Book(Guid id)
        {
            Id = id;
        }
    }
}
