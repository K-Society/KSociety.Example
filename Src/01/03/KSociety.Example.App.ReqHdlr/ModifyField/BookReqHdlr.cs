using KSociety.Base.App.Shared;
using KSociety.Base.Infra.Abstraction.Interface;
using KSociety.Example.App.Dto.Req.ModifyField;
using KSociety.Example.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace KSociety.Example.App.ReqHdlr.ModifyField
{
    public class BookReqHdlr : IRequestHandlerWithResponseAsync<Book, KSociety.Example.App.Dto.Res.ModifyField.Book>
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

        public async ValueTask<KSociety.Example.App.Dto.Res.ModifyField.Book> ExecuteAsync(Book request, CancellationToken cancellationToken = default)
        {
            var book = await _bookRepository.FindAsync(cancellationToken, request.Id).ConfigureAwait(false);
            book?.ModifyField(request.FieldName, request.Value);
            var result = await _unitOfWork.CommitAsync(cancellationToken).ConfigureAwait(false);
            return new KSociety.Example.App.Dto.Res.ModifyField.Book(result > 0);
        }
    }
}
