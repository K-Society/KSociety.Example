using AutoMapper;
using KSociety.Base.App.Shared;
using KSociety.Base.Infra.Abstraction.Interface;
using KSociety.Example.App.Dto.Req.Copy;
using KSociety.Example.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace KSociety.Example.App.ReqHdlr.Copy
{
    public class BookReqHdlr : IRequestHandlerWithResponseAsync<Book, KSociety.Example.App.Dto.Res.Copy.Book>
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<BookReqHdlr> _logger;
        private readonly IDatabaseUnitOfWork _unitOfWork;
        private readonly IBook _bookRepository;
        private readonly IMapper _mapper;

        public BookReqHdlr(ILoggerFactory loggerFactory, IDatabaseUnitOfWork unitOfWork, IBook bookRepository, IMapper mapper)
        {
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<BookReqHdlr>();
            _unitOfWork = unitOfWork;
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async ValueTask<KSociety.Example.App.Dto.Res.Copy.Book> ExecuteAsync(Book request, CancellationToken cancellationToken = default)
        {
            var book = _mapper.Map<Domain.Entity.Book>(request);
            var entryEntity = await _bookRepository.AddAsync(book, cancellationToken).ConfigureAwait(false);
            var result = await _unitOfWork.CommitAsync(cancellationToken).ConfigureAwait(false);
            return result == -1 ? new KSociety.Example.App.Dto.Res.Copy.Book(Guid.Empty) : new KSociety.Example.App.Dto.Res.Copy.Book(book.Id);
        }
    }
}
