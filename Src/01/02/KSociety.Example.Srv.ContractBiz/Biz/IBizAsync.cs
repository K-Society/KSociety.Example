using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace KSociety.Example.Srv.ContractBiz.Biz
{
    [Service]
    public interface IBizAsync
    {
        [Operation]
        ValueTask<App.DtoBiz.Res.Biz.TestExample> GetTestExampleAsync(App.DtoBiz.Req.Biz.TestExample request, CallContext context = default);
    }
}
