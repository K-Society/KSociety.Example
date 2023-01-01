using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace KSociety.Example.Srv.Contract.Query.List
{
    [Service]
    public interface IQueryAsync
    {
        [Operation]
        ValueTask<Srv.Dto.List.Book> BookAsync(CallContext context = default);
    }
}
