using KSociety.Base.Srv.Agent;
using KSociety.Base.Srv.Dto;
using KSociety.Example.Srv.Contract.Query;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc.Client;

namespace KSociety.Example.Srv.Agent.Query
{
    public class Book : KSociety.Base.Srv.Agent.Connection, KSociety.Example.Srv.Agent.Interface.Query.IBook
    {
        public Book(IAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
            : base(agentConfiguration, loggerFactory)
        {

        }

        public async ValueTask<Srv.Dto.Book> FindAsync(IdObject idObject, CancellationToken cancellationToken = default)
        {
            Logger.LogTrace("Query Agent: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " " + idObject.Id);
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<IQueryAsync>();

                    return await client.GetBookByIdAsync(idObject, ConnectionOptions(cancellationToken));
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);
            }
            return await new ValueTask<Dto.Book>();
        }
    }
}
