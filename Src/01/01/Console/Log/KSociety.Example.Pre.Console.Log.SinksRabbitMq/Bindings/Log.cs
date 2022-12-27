using Autofac;
using Microsoft.Extensions.Logging;
using Serilog.Extensions.Logging;

namespace KSociety.Example.Pre.Console.Log.SinksRabbitMq.Bindings
{
    public class Log : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(_ => new LoggerFactory(new ILoggerProvider[] { new SerilogLoggerProvider() }))
                .As<ILoggerFactory>()
                .SingleInstance();

            builder.RegisterGeneric(typeof(Logger<>))
                .As(typeof(ILogger<>))
                .SingleInstance();
        }
    }
}
