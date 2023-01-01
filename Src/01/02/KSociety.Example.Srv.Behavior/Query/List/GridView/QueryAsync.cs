using AutoMapper;
using KSociety.Example.Domain.Repository;
using KSociety.Example.Srv.Contract.Query.List.GridView;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc;

namespace KSociety.Example.Srv.Behavior.Query.List.GridView
{
    public class QueryAsync : IQueryAsync
    {
        private readonly ILogger<QueryAsync> _logger;
        private readonly IMapper _mapper;
        private readonly IBook _bookRepository;

        public QueryAsync(
            ILoggerFactory loggerFactory,
            IMapper mapper,
            IBook bookRepository
        )
        {
            _logger = loggerFactory.CreateLogger<QueryAsync>();
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        public async ValueTask<Srv.Dto.List.GridView.Book> BookAsync(CallContext context = default)
        {
            _logger.LogTrace("Query Behavior: " + GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod()?.Name);

            var repository = await _bookRepository.GetAllBookAsync();
            var bookItems = repository.ToList().Select(
                book => _mapper.Map<Srv.Dto.Book>(book)
            ).ToList();

            var output = new Srv.Dto.List.GridView.Book(bookItems);

            return output;
        }
    }
}
