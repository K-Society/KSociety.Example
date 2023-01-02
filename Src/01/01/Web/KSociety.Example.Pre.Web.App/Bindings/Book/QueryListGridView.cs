using Autofac;
using KSociety.Example.Srv.Agent;

namespace KSociety.Example.Pre.Web.App.Bindings.Book;

public class QueryListGridView : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<LoggerFactory>().As<ILoggerFactory>().SingleInstance();
        // Create Logger<T> when ILogger<T> is required.
        builder.RegisterGeneric(typeof(Logger<>))
            .As(typeof(ILogger<>));

        var agentConfiguration = new ExampleAgentConfiguration("http://localhost:5001", true);
        builder.RegisterInstance(agentConfiguration).As<IExampleAgentConfiguration>().SingleInstance();

        builder.RegisterType<KSociety.Example.Srv.Agent.Query.List.GridView.Book>()
            .As<KSociety.Example.Srv.Agent.Interface.Query.List.GridView.IBook>().SingleInstance();

    }
}