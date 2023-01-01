using KSociety.Base.Infra.Abstraction.Interface;
using KSociety.Example.Infra.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace KSociety.Example.Infra.Transfer.Sqlite
{
    public sealed class SqliteExampleContext : ExampleContext
    {
        public SqliteExampleContext(ILoggerFactory loggerFactory, IDatabaseConfiguration configuration, IMediator mediator)
            : base(loggerFactory, configuration, mediator)
        {

        }

        public SqliteExampleContext(DbContextOptions<SqliteExampleContext> options)
            : base(options)
        {

        }
    }
}
