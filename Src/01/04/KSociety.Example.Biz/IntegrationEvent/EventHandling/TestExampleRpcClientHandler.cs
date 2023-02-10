using Autofac;
using KSociety.Base.EventBus.Handlers;
using KSociety.Example.Biz.Event;
using Microsoft.Extensions.Logging;

namespace KSociety.Example.Biz.IntegrationEvent.EventHandling;

public class TestExampleRpcClientHandler : IntegrationRpcClientHandler<TestExampleEventReply>
{
    public TestExampleRpcClientHandler(ILoggerFactory loggerFactory, IComponentContext componentContext)
        : base(loggerFactory, componentContext)
    {

    }

    public override void HandleReply(TestExampleEventReply @integrationEventReply, CancellationToken cancel = default)
    {
        //await Queue.SendAsync(@integrationEventReply, cancel).ConfigureAwait(false);
        Logger.LogWarning("TestExampleRpcClientHandler HandleRpc: NotImplemented! " + @integrationEventReply.RoutingKey);
        //throw new NotImplementedException();
    }

    public override async ValueTask HandleReplyAsync(TestExampleEventReply @integrationEventReply, CancellationToken cancel = default)
    {
        //await Queue.SendAsync(@integrationEventReply, cancel).ConfigureAwait(false);
        ;
        Logger.LogWarning("TestExampleRpcClientHandler HandleRpcAsync: NotImplemented! " + @integrationEventReply.RoutingKey);
        //throw new NotImplementedException();
    }
}