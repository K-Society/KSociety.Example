using Autofac;

namespace KSociety.Example.Srv.Host.Bindings
{
    public class QueryListGridView : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<Srv.Behavior.Query.ListKeyValue.Query>().As<Srv.Contract.Query.ListKeyValue.IQuery>();
            //builder.RegisterType<Srv.Behavior.Query.ListKeyValue.QueryAsync>().As<Srv.Contract.Query.ListKeyValue.IQueryAsync>();

            
        }
    }
}
