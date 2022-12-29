using AutoMapper;
using KSociety.Base.App.Shared;
using KSociety.Base.Infra.Abstraction.Interface;
using KSociety.Example.App.Dto.Req.Update;
using KSociety.Example.Domain.Repository;
using Microsoft.Extensions.Logging;

namespace KSociety.Example.App.ReqHdlr.Update
{
    public class BookReqHdlr : IRequestHandlerWithResponseAsync<Book, KSociety.Example.App.Dto.Res.Update.Book>
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

        public async ValueTask<KSociety.Example.App.Dto.Res.Update.Book> ExecuteAsync(Book request, CancellationToken cancellationToken = default)
        {
            var book = _mapper.Map<Domain.Entity.Book>(request);
            var entryEntity = _bookRepository.Update(book);
            var result = await _unitOfWork.CommitAsync(cancellationToken).ConfigureAwait(false);
            return result == -1 ? new KSociety.Example.App.Dto.Res.Update.Book(Guid.Empty) : new KSociety.Example.App.Dto.Res.Update.Book(book.Id);
        }
    }
}
