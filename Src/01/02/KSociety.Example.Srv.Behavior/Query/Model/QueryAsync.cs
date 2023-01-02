using Azure;
using KSociety.Base.Srv.Dto;
using KSociety.Example.Domain.Repository;
using KSociety.Example.Srv.Contract.Query.Model;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc;

namespace KSociety.Example.Srv.Behavior.Query.Model
{
    public class QueryAsync : IQueryAsync
    {
        private readonly ILogger<QueryAsync> _logger;
        private readonly IBook _bookRepository;

        public QueryAsync(
            ILoggerFactory loggerFactory,
            IBook bookRepository
        )
        {
            _logger = loggerFactory.CreateLogger<QueryAsync>();
            _bookRepository = bookRepository;
        }

        public async ValueTask<Srv.Dto.Model.Book> GetBookModelByIdAsync(IdObject idObject, CallContext context = default)
        {
            Domain.Entity.Book book = null;
            _logger.LogTrace("Query Behavior: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);

            if (idObject.Id.Equals(Guid.Empty))
            {
                book = new Domain.Entity.Book();
            }
            else
            {
                book = await _bookRepository.FindAsync(context.CancellationToken, idObject.Id);
            }

            return new Dto.Model.Book(new Dto.Book(book.Id, book.Title, book.AuthorName));
        }
    }
}
