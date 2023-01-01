using Autofac;

namespace KSociety.Example.Srv.Host.Bindings
{
    public class QueryModel : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Srv.Behavior.Query.QueryAsync>().As<Srv.Contract.Query.IQueryAsync>();
        }
    }
}
