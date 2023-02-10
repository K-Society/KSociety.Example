using ProtoBuf;

namespace KSociety.Example.Biz.Event
{

    [ProtoContract]
    public class TestExampleEvent : IntegrationExampleEventRpc
    {
        [ProtoMember(1)] 
        public string TestName { get; set; }

        [ProtoMember(2)] 
        public string TestMessage { get; set; }

        public TestExampleEvent() { }

        public TestExampleEvent(
            string routingKey,
            string replyRoutingKey,
            string testName,
            string testMessage
        )
            : base(routingKey, replyRoutingKey)
        {
            TestName = testName;
            TestMessage = testMessage;
        }
    }
}
