using KSociety.Base.EventBus.Events;
using ProtoBuf;

namespace KSociety.Example.Biz.Event
{
    [ProtoContract]
    public class IntegrationExampleEventReply : IntegrationEventReply
    {
        public IntegrationExampleEventReply()
        {

        }

        public IntegrationExampleEventReply(string routingKey)
            : base(routingKey)
        {

        }
    }
}