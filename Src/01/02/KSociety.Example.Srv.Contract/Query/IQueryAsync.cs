using KSociety.Base.Srv.Dto;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace KSociety.Example.Srv.Contract.Query
{
    [Service]
    public interface IQueryAsync
    {
        [Operation]
        ValueTask<Srv.Dto.Book> GetBookByIdAsync(IdObject idObject, CallContext context = default);
    }
}
