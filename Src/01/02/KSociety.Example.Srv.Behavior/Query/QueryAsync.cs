using KSociety.Base.Srv.Dto;
using KSociety.Example.Domain.Repository;
using KSociety.Example.Srv.Contract.Query;
using KSociety.Example.Srv.Dto;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc;

namespace KSociety.Example.Srv.Behavior.Query
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

        public async ValueTask<Srv.Dto.Book> GetBookByIdAsync(IdObject idObject, CallContext context = default)
        {
            Domain.Entity.Book book = null;
            _logger.LogTrace("Query Behavior: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);
            try
            {
                book = await _bookRepository.FindAsync(context.CancellationToken, idObject.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Query Behavior: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);
            }

            return new Book(book.Id, book.Title, book.AuthorName);
        }
    }
}
