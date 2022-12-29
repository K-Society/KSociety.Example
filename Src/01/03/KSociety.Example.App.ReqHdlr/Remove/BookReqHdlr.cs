using KSociety.Base.App.Shared;
using KSociety.Base.Infra.Abstraction.Interface;
using KSociety.Example.App.Dto.Req.Remove;
using KSociety.Example.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace KSociety.Example.App.ReqHdlr.Remove
{
    public class BookReqHdlr : IRequestHandlerWithResponseAsync<Book, KSociety.Example.App.Dto.Res.Remove.Book>
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<BookReqHdlr> _logger;
        private readonly IDatabaseUnitOfWork _unitOfWork;
        private readonly IBook _bookRepository;

        public BookReqHdlr(ILoggerFactory loggerFactory, IDatabaseUnitOfWork unitOfWork, IBook bookRepository)
        {
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<BookReqHdlr>();
            _unitOfWork = unitOfWork;
            _bookRepository = bookRepository;
        }

        public async ValueTask<KSociety.Example.App.Dto.Res.Remove.Book> ExecuteAsync(Book request, CancellationToken cancellationToken = default)
        {
            var commonConnection = await _bookRepository.FindAsync(cancellationToken, request.Id).ConfigureAwait(false);

            _bookRepository.Delete(commonConnection);

            return new KSociety.Example.App.Dto.Res.Remove.Book(await _unitOfWork.CommitAsync(cancellationToken).ConfigureAwait(false) > 0);
        }
    }
}
