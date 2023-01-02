using KSociety.Base.Srv.Agent;
using KSociety.Base.Srv.Dto;
using KSociety.Example.Srv.Contract.Query.Model;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc.Client;

namespace KSociety.Example.Srv.Agent.Query.Model
{
    public class Book : KSociety.Base.Srv.Agent.Connection, KSociety.Example.Srv.Agent.Interface.Query.Model.IBook
    {
        public Book(IAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
            : base(agentConfiguration, loggerFactory)
        {

        }

        public async ValueTask<Srv.Dto.Model.Book> FindAsync(IdObject idObject, CancellationToken cancellationToken = default)
        {
            Logger.LogTrace("Query Agent: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " " + idObject.Id);
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<IQueryAsync>();

                    return await client.GetBookModelByIdAsync(idObject, ConnectionOptions(cancellationToken));
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);
            }
            return await new ValueTask<Dto.Model.Book>();
        }
    }
}
