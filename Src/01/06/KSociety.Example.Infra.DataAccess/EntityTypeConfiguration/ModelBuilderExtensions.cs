using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KSociety.Example.Infra.DataAccess.EntityTypeConfiguration
{
    public static  class ModelBuilderExtensions
    {
        public static void SeedBook(this ModelBuilder modelBuilder, ILoggerFactory loggerFactory)
        {
            modelBuilder.Entity<Domain.Entity.Book>().HasData
            (
                new Domain.Entity.Book(Guid.NewGuid(), "1", "1"),
                new Domain.Entity.Book(Guid.NewGuid(), "2", "2"),
                new Domain.Entity.Book(Guid.NewGuid(), "3", "3"),
                new Domain.Entity.Book(Guid.NewGuid(), "4", "4"),
                new Domain.Entity.Book(Guid.NewGuid(), "5", "5")
            );
        }
    }
}
