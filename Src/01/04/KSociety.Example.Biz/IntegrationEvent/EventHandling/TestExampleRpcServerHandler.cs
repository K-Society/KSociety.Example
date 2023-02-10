using Autofac;
using KSociety.Base.EventBus.Handlers;
using KSociety.Example.Biz.Event;
using KSociety.Example.Biz.Interface;
using Microsoft.Extensions.Logging;

namespace KSociety.Example.Biz.IntegrationEvent.EventHandling;

public class TestExampleRpcServerHandler : IntegrationRpcServerHandler<TestExampleEvent, TestExampleEventReply>
{
    private readonly IBiz _biz;
    public TestExampleRpcServerHandler(
        ILoggerFactory loggerFactory,
        IComponentContext componentContext
    )
        : base(loggerFactory, componentContext)
    {
        if (ComponentContext.IsRegistered<IBiz>())
        {
            _biz = ComponentContext.Resolve<IBiz>();
        }
        else
        {
            Logger.LogError("IBiz not Registered!");
        }
    }

    public override async ValueTask<TestExampleEventReply> HandleRpcAsync(TestExampleEvent @event, CancellationToken cancellationToken = default)
    {

        //var connectionRead = _biz.GetConnectionReadStatus(@event.GroupName, @event.ConnectionName); 
        //var connectionWrite = _biz.GetConnectionWriteStatus(@event.GroupName, @event.ConnectionName);

        return new TestExampleEventReply(@event.ReplyRoutingKey, @event.TestName, @event.TestMessage);
    }
}