using Autofac;
using KSociety.Log.Serilog.Sinks.RichTextBoxQueue.Wpf.Sinks.RichTextBoxQueue;
using Microsoft.Extensions.Logging;
using Serilog.Extensions.Logging;

namespace KSociety.Example.Pre.Wpf.LogViewerAppIoC.Bindings
{
    public class Log : Module
    {
        private readonly RichTextBoxQueueSink _richTextBoxQueueSink;

        public Log(RichTextBoxQueueSink richTextBoxQueueSink)
        {
            _richTextBoxQueueSink = richTextBoxQueueSink;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(_ => new LoggerFactory(new ILoggerProvider[] {new SerilogLoggerProvider()}))
                .As<ILoggerFactory>();

            builder.RegisterInstance(_richTextBoxQueueSink).As<IRichTextBoxQueueSink>();

            builder.RegisterGeneric(typeof(Logger<>))
                .As(typeof(ILogger<>));

            
        }
    }
}
