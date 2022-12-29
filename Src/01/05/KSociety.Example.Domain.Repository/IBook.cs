using KSociety.Base.Infra.Shared.Interface;
using KSociety.Example.Domain.Entity;

namespace KSociety.Example.Domain.Repository
{
    public interface IBook : IRepository<Book>
    {
        IEnumerable<Book> GetAllBook();

        ValueTask<IEnumerable<Book>> GetAllBookAsync();
    }
}
