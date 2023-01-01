using Autofac;
using KSociety.Base.Srv.Shared.Interface;
using KSociety.Example.Srv.Contract.Command;
using Microsoft.Extensions.Logging;

namespace KSociety.Example.Srv.Behavior.Command
{
    public class BookAsync : KSociety.Base.Srv.Behavior.CommandAsync<
        KSociety.Example.App.Dto.Req.Add.Book, KSociety.Example.App.Dto.Res.Add.Book,
        KSociety.Example.App.Dto.Req.Update.Book, KSociety.Example.App.Dto.Res.Update.Book,
        KSociety.Example.App.Dto.Req.Copy.Book, KSociety.Example.App.Dto.Res.Copy.Book,
        KSociety.Example.App.Dto.Req.ModifyField.Book, KSociety.Example.App.Dto.Res.ModifyField.Book,
        KSociety.Example.App.Dto.Req.Remove.Book, KSociety.Example.App.Dto.Res.Remove.Book>, IBookAsync
    {
        public BookAsync(
            ILoggerFactory loggerFactory,
            IComponentContext componentContext,
            ICommandHandlerAsync commandHandlerAsync
        ) : base(loggerFactory, componentContext, commandHandlerAsync)
        {

        }
    }
}
