using KSociety.Base.Srv.Agent;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc.Client;

namespace KSociety.Example.Srv.AgentBiz.Biz
{
    public class Biz : KSociety.Base.Srv.Agent.Connection, KSociety.Example.Srv.AgentBiz.Interface.IBiz
    {
        public Biz(IAgentConfiguration agentConfiguration, ILoggerFactory loggerFactory)
            : base(agentConfiguration, loggerFactory)
        {

        }

        public async ValueTask<App.DtoBiz.Res.Biz.TestExample> GetTestExampleAsync(App.DtoBiz.Req.Biz.TestExample request, CancellationToken cancellationToken = default)
        {
            App.DtoBiz.Res.Biz.TestExample output = new App.DtoBiz.Res.Biz.TestExample();
            try
            {
                using (Channel)
                {
                    ContractBiz.Biz.IBizAsync client = Channel.CreateGrpcService<KSociety.Example.Srv.ContractBiz.Biz.IBizAsync>();

                    var result = await client.GetTestExampleAsync(request, ConnectionOptions(cancellationToken));

                    output = result;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name + " - " + ex.Source + " " + ex.Message + " " + ex.StackTrace);
            }
            return output;
        }
    }
}
