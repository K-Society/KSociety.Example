using Autofac;
using KSociety.Base.EventBus.Handlers;
using KSociety.Example.Biz.Event;
using KSociety.Example.Biz.Interface;
using Microsoft.Extensions.Logging;

namespace KSociety.Example.Biz.IntegrationEvent.EventHandling;

public class TestExampleRpcHandler : IntegrationRpcHandler<TestExampleEvent, TestExampleEventReply>
{
    private readonly IBiz _biz;

    public TestExampleRpcHandler(
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
        try
        {
            //connectionRead = _biz.GetConnectionReadStatus(@event.GroupName, @event.ConnectionName);
            //connectionWrite = _biz.GetConnectionWriteStatus(@event.GroupName, @event.ConnectionName);
        }catch(Exception ex)
        {
            Logger.LogError(ex, "TestExampleRpcHandler: ");
        }

        return new TestExampleEventReply(@event.TestName + ".example.test", @event.TestName, @event.TestMessage);
    }
}