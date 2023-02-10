using KSociety.Base.EventBus.Events;
using KSociety.Example.Biz.Event;

namespace KSociety.Example.Srv.ContractBiz.ProtoModel
{
    public static class Configuration
    {
        public static void ProtoBufConfiguration()
        {
            //IntegrationEvent

            ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(IntegrationEventRpc), true)
                .AddSubType(601, typeof(IntegrationExampleEventRpc));

            ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(IntegrationExampleEventRpc), true)
                .AddSubType(601, typeof(TestExampleEvent));

            ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(IntegrationEventReply), true)
                .AddSubType(611, typeof(IntegrationExampleEventReply));

            ProtoBuf.Meta.RuntimeTypeModel.Default.Add(typeof(IntegrationExampleEventReply), true)
                .AddSubType(611, typeof(TestExampleEventReply));


        }
    }
}
