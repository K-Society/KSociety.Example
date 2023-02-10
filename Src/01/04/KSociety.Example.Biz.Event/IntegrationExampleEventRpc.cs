using KSociety.Base.EventBus.Events;
using ProtoBuf;

namespace KSociety.Example.Biz.Event
{
    [ProtoContract]
    public class IntegrationExampleEventRpc : IntegrationEventRpc
    {
        public IntegrationExampleEventRpc()
        {

        }

        public IntegrationExampleEventRpc(string routingKey, string replyRoutingKey)
            : base(routingKey, replyRoutingKey)
        {

        }
    }
}
