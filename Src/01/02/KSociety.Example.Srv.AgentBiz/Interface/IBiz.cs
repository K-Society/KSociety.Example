using ProtoBuf.Grpc;

namespace KSociety.Example.Srv.AgentBiz.Interface
{
    public interface IBiz
    {
        ValueTask<App.DtoBiz.Res.Biz.TestExample> GetTestExampleAsync(App.DtoBiz.Req.Biz.TestExample request, CancellationToken cancellationToken = default);
    }
}
