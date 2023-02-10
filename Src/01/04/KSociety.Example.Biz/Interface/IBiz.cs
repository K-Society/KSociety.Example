using KSociety.Example.Biz.Event;

namespace KSociety.Example.Biz.Interface
{
    public interface IBiz
    {
        void LoadEventBus();

        ValueTask<TestExampleEventReply> GetTestExampleAsync(TestExampleEvent testExampleEvent,
            CancellationToken cancellationToken = default);
    }
}
