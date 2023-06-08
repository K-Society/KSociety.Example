using Autofac;
using KSociety.Base.EventBus;
using KSociety.Base.EventBus.Abstractions.EventBus;
using KSociety.Base.EventBusRabbitMQ;
using KSociety.Base.EventBusRabbitMQ.Helper;
using KSociety.Example.Biz.Event;
using KSociety.Example.Biz.IntegrationEvent.EventHandling;
using KSociety.Example.Biz.Interface;
using Microsoft.Extensions.Logging;

namespace KSociety.Example.Biz.Class
{
    public class Biz : IBiz
    {
        private readonly ILogger<Biz> _logger;
        private readonly ILoggerFactory _loggerFactory;
        private readonly IEventBusParameters _eventBusParameters;
        private readonly IRabbitMqPersistentConnection _persistentConnection;
        private readonly Subscriber _subscriber;
        private const string EventBusName = "Example";
        private readonly IComponentContext _componentContext;

        public Biz(
            ILoggerFactory loggerFactory,
            IEventBusParameters eventBusParameters,
            IRabbitMqPersistentConnection persistentConnection,
            IComponentContext componentContext)
        {
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<Biz>();
            _eventBusParameters = eventBusParameters;
            _persistentConnection = persistentConnection;
            _logger.LogInformation("KSociety.Example.Biz.Class.Biz!");
            _subscriber = new Subscriber(_loggerFactory, _persistentConnection, _eventBusParameters);
            _componentContext = componentContext;
        }

        public void LoadEventBus()
        {
            //_subscriber.SubscribeTyped<LogEventHandler, WriteLogEvent>(
            //    EventBusName, "ExampleQueueServer", "example", new LogEventHandler(_loggerFactory)
            //);

            _subscriber.SubscribeClientServer<
                TestExampleRpcClientHandler, TestExampleRpcServerHandler,
                TestExampleEvent, TestExampleEventReply>(
                EventBusName,
                "BusinessQueueConnection_Example",
                "example.server",
                "example.client.com",
                new TestExampleRpcClientHandler(_loggerFactory, _componentContext),
                new TestExampleRpcServerHandler(_loggerFactory, _componentContext));
        }

        #region [Get Set to Plc]

        public bool GetTestExampleAsync(string groupName, string connectionName)
        {
            return true;
        }

        #endregion

        #region [Handler]

        public async ValueTask<TestExampleEventReply> GetTestExampleAsync(TestExampleEvent testExampleEvent, CancellationToken cancellationToken = default)
        {
            if (_subscriber.EventBus.ContainsKey(connectionStatusIntegrationEvent.GroupName + "_Connection_Client"))
            {
                return await ((IEventBusRpcClient) _subscriber.EventBus[
                        connectionStatusIntegrationEvent.GroupName + "_Connection_Client"])
                    .CallAsync<TestExampleEventReply>(testExampleEvent, cancellationToken).ConfigureAwait(false);
            }

            _logger.LogError("GetTestExampleAsync: " + testExampleEvent.TestName + " " + testExampleEvent.TestMessage + " Error!");

            return new TestExampleEventReply();
        }

        #endregion
    }
}
