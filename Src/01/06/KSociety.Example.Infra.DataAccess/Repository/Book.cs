using KSociety.Base.Infra.Shared.Class;
using KSociety.Base.Infra.Shared.Interface;
using KSociety.Example.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KSociety.Example.Infra.DataAccess.Repository
{
    public class Book<TContext>
        : RepositoryBase<TContext, Domain.Entity.Book>, IBook
        where TContext : DatabaseContext
    {
        public Book(ILoggerFactory logFactory, IDatabaseFactory<TContext> databaseFactory)
            : base(logFactory, databaseFactory)
        {
        }

        public IEnumerable<Domain.Entity.Book> GetAllBook()
        {
            return FindAll().OrderBy(x => x.Title).ToList();
        }

        public async ValueTask<IEnumerable<Domain.Entity.Book>> GetAllBookAsync()
        {
            return await FindAll().OrderBy(x => x.Title).ToListAsync();
        }
    }
}
