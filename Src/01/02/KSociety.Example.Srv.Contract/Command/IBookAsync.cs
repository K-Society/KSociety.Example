using ProtoBuf.Grpc.Configuration;

namespace KSociety.Example.Srv.Contract.Command
{
    [Service]
    public interface IBookAsync : KSociety.Base.Srv.Contract.ICommandAsync<
        KSociety.Example.App.Dto.Req.Add.Book, KSociety.Example.App.Dto.Res.Add.Book,
        KSociety.Example.App.Dto.Req.Update.Book, KSociety.Example.App.Dto.Res.Update.Book,
        KSociety.Example.App.Dto.Req.Copy.Book, KSociety.Example.App.Dto.Res.Copy.Book,
        KSociety.Example.App.Dto.Req.ModifyField.Book, KSociety.Example.App.Dto.Res.ModifyField.Book,
        KSociety.Example.App.Dto.Req.Remove.Book, KSociety.Example.App.Dto.Res.Remove.Book>
    {
    }
}
