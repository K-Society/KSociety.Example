using KSociety.Base.Srv.Agent;
using KSociety.Base.Srv.Dto;

namespace KSociety.Example.Srv.Agent.Interface.Query.Model
{
    public interface IBook : IAgentQueryModelAsync<IdObject, Srv.Dto.Model.Book>
    {
    }
}
