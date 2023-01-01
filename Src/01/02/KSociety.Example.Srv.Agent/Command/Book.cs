using KSociety.Base.Srv.Agent;
using Microsoft.Extensions.Logging;

namespace KSociety.Example.Srv.Agent.Command
{
    public class Book : KSociety.Base.Srv.Agent.AgentCommandAsync<
            KSociety.Example.Srv.Contract.Command.IBookAsync,
            KSociety.Example.App.Dto.Req.Add.Book, KSociety.Example.App.Dto.Res.Add.Book,
            KSociety.Example.App.Dto.Req.Update.Book, KSociety.Example.App.Dto.Res.Update.Book,
            KSociety.Example.App.Dto.Req.Copy.Book, KSociety.Example.App.Dto.Res.Copy.Book,
            KSociety.Example.App.Dto.Req.ModifyField.Book, KSociety.Example.App.Dto.Res.ModifyField.Book,
            KSociety.Example.App.Dto.Req.Remove.Book, KSociety.Example.App.Dto.Res.Remove.Book>,
            KSociety.Example.Srv.Agent.Interface.Command.IBook
    {
        public Book(IAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
            : base(agentConfiguration, loggerFactory)
        {

        }
    }
}
