using Autofac;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace KSociety.Example.Pre.Console.Log.SinksRabbitMq
{
    internal class Program
    {
        private static void Main()
        {
            KSociety.Log.Serilog.Sinks.RabbitMq.ProtoModel.Configuration.ProtoBufConfiguration();

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            global::Serilog.Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();

            try
            {
                var builder = new ContainerBuilder();
                builder.RegisterModule(new Bindings.Log());
                var container = builder.Build();

                var loggerFactory = container.Resolve<ILoggerFactory>();
                var logger = loggerFactory.CreateLogger<Program>();

                LogMessages(logger);
            }
            catch (Exception ex)
            {
                global::Serilog.Log.Fatal(ex, "The program was stopped due to an exception.");
                throw;
            }
            finally
            {
                global::Serilog.Log.CloseAndFlush();
            }
        }

        private static void LogMessages(ILogger logger)
        {
            System.Console.WriteLine("Enter your message: ");
            var result = System.Console.ReadLine();
            logger.LogTrace("Your {0} message: {1}", "Trace", result);
            logger.LogDebug("Your {0} message: {1}", "Debug", result);
            logger.LogInformation("Your {0} message: {1}", "Information", result);
            logger.LogWarning("Your {0} message: {1}", "Warning", result);
            logger.LogError("Your {0} message: {1}", "Error", result);
        }
    }
}
