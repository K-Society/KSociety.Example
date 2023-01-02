using KSociety.Base.Srv.Dto;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace KSociety.Example.Srv.Contract.Query.Model
{
    [Service]
    public interface IQueryAsync
    {
        [Operation]
        ValueTask<Srv.Dto.Model.Book> GetBookModelByIdAsync(IdObject idObject, CallContext context = default);
    }
}
