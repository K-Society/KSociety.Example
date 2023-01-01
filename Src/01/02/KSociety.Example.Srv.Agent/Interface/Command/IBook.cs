using KSociety.Base.Srv.Agent;

namespace KSociety.Example.Srv.Agent.Interface.Command
{
    public interface IBook : IAgentCommandAsync<
        App.Dto.Req.Add.Book,
        App.Dto.Res.Add.Book,
        App.Dto.Req.Update.Book,
        App.Dto.Res.Update.Book,
        App.Dto.Req.Copy.Book,
        App.Dto.Res.Copy.Book,
        App.Dto.Req.ModifyField.Book,
        App.Dto.Res.ModifyField.Book,
        App.Dto.Req.Remove.Book,
        App.Dto.Res.Remove.Book>
    {
    }
}
