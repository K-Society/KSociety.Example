using KSociety.Base.Infra.Abstraction.Interface;
using KSociety.Base.Infra.Shared.Class;
using KSociety.Example.Infra.DataAccess.EntityTypeConfiguration;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KSociety.Example.Infra.DataAccess
{
    public class ExampleContext : DatabaseContext
    {
        public ExampleContext(ILoggerFactory loggerFactory, IDatabaseConfiguration configuration, IMediator mediator)
            : base(loggerFactory, configuration, mediator)
        {

        }

        public ExampleContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new Book());

            modelBuilder.SeedBook(LoggerFactory);
        }
    }
}
