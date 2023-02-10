using ProtoBuf;

namespace KSociety.Example.Biz.Event
{
    [ProtoContract]
    public class TestExampleEventReply : IntegrationExampleEventReply
    {
        [ProtoMember(1)]
        public string TestName { get; set; }

        [ProtoMember(2)]
        public string TestMessage { get; set; }

        public TestExampleEventReply() { }

        public TestExampleEventReply(
            string routingKey,
            string testName,
            string testMessage
        )
            : base(routingKey)
        {
            TestName = testName;
            TestMessage = testMessage;
        }
    }
}
