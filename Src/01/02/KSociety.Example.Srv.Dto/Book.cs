using KSociety.Base.InfraSub.Shared.Interface;
using ProtoBuf;
using System.ComponentModel;

namespace KSociety.Example.Srv.Dto
{
    [ProtoContract]
    public class Book : IAppDtoObject<
        App.Dto.Req.Remove.Book,
        App.Dto.Req.Add.Book,
        App.Dto.Req.Update.Book,
        App.Dto.Req.Copy.Book>
    {

        [ProtoMember(1), CompatibilityLevel(CompatibilityLevel.Level200)]
        [Browsable(false)]
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

        public App.Dto.Req.Remove.Book GetRemoveReq()
        {
            return new App.Dto.Req.Remove.Book(Id);
        }

        public App.Dto.Req.Add.Book GetAddReq()
        {
            return new App.Dto.Req.Add.Book(Title, AuthorName);
        }

        public App.Dto.Req.Update.Book GetUpdateReq()
        {
            return new App.Dto.Req.Update.Book(Id, Title, AuthorName);
        }

        public App.Dto.Req.Copy.Book GetCopyReq()
        {
            return new App.Dto.Req.Copy.Book(Title, AuthorName);
        }
    }
}
