using KSociety.Base.Srv.Agent;
using KSociety.Example.Srv.Contract.Query.List.GridView;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc.Client;

namespace KSociety.Example.Srv.Agent.Query.List.GridView
{
    public class Book : KSociety.Base.Srv.Agent.Connection, KSociety.Example.Srv.Agent.Interface.Query.List.GridView.IBook
    {
        public Book(IAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
            : base(agentConfiguration, loggerFactory)
        {

        }

        public async ValueTask<Srv.Dto.List.GridView.Book> LoadAllRecordsAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                using (Channel)
                {
                    var client = Channel.CreateGrpcService<IQueryAsync>();

                    return await client.BookAsync(ConnectionOptions(cancellationToken));
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);
            }
            return null;
        }
    }
}
