using KSociety.Example.Biz.Event;

namespace KSociety.Example.Biz.Interface
{
    public interface IBiz
    {
        void LoadEventBus();

        bool GetTestExampleAsync(string groupName, string connectionName);

        ValueTask<TestExampleEventReply> GetTestExampleAsync(TestExampleEvent testExampleEvent,
            CancellationToken cancellationToken = default);
    }
}
