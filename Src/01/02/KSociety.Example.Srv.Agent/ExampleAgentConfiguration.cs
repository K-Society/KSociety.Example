using KSociety.Base.Srv.Agent;

namespace KSociety.Example.Srv.Agent
{
    public class ExampleAgentConfiguration : AgentConfiguration, IExampleAgentConfiguration
    {
        public ExampleAgentConfiguration(string connectionUrl, bool debugFlag)
            : base(connectionUrl, debugFlag)
        {

        }
    }
}
