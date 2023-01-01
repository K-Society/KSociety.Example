using Autofac;
using KSociety.Base.Infra.Shared.Class;

namespace KSociety.Example.Srv.Host.Bindings
{
    public class Repository<TContext> : Module where TContext : DatabaseContext
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Infra.DataAccess.Repository.Book<TContext>>().As<Domain.Repository.IBook>();
        }
    }
}
