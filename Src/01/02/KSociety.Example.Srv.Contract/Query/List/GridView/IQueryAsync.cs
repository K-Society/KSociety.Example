using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace KSociety.Example.Srv.Contract.Query.List.GridView
{
    [Service]
    public interface IQueryAsync
    {
        [Operation]
        ValueTask<Srv.Dto.List.GridView.Book> BookAsync(CallContext context = default);
    }
}
