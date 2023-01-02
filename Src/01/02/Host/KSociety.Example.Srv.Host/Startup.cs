using Autofac;
using KSociety.Base.Infra.Abstraction.Class;
using KSociety.Base.Infra.Shared.Class;
using KSociety.Base.InfraSub.Shared.Class;
using KSociety.Example.Infra.Transfer.Sqlite;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ProtoBuf.Grpc.Server;

namespace KSociety.Example.Srv.Host
{
    public class Startup
    {
        public ILifetimeScope AutofacContainer { get; private set; }
        private bool DebugFlag { get; }
        private DatabaseOptions DatabaseOptions { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            DebugFlag = Configuration.GetValue<bool>("DebugFlag");

            DatabaseOptions = Configuration.GetSection("Database").Get<DatabaseOptions>();

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            try
            {
                KSociety.Example.Srv.Contract.ProtoModel.Configuration.ProtoBufConfiguration();
                services.AddCodeFirstGrpc();

            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Startup ConfigureServices: " + ex.Message + " " + ex.StackTrace);
            }
        }

        // ConfigureContainer is where you can register things directly
        // with Autofac. This runs after ConfigureServices so the things
        // here will override registrations made in ConfigureServices.
        // Don't build the container; that gets done for you by the factory.
        public void ConfigureContainer(ContainerBuilder builder)
        {
            switch (DatabaseOptions.DatabaseEngine)
            {
                case DatabaseEngine.Sqlserver:
                    throw new ArgumentOutOfRangeException();
                    //RegisterModule<SqlServerComContext>(builder);
                    break;

                case DatabaseEngine.Sqlite:
                    RegisterModule<SqliteExampleContext>(builder);
                    break;

                case DatabaseEngine.Npgsql:
                    throw new ArgumentOutOfRangeException();
                    //RegisterModule<NpgsqlComContext>(builder);
                    break;

                case DatabaseEngine.Mysql:
                    throw new ArgumentOutOfRangeException();
                    //RegisterModule<MySqlComContext>(builder);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void RegisterModule<TContext>(ContainerBuilder builder) where TContext : DatabaseContext
        {
            try
            {
                //Log.
                builder.RegisterModule(new Base.Srv.Host.Shared.Bindings.Log());

                //AutoMapper.
                builder.RegisterModule(new KSociety.Base.Srv.Host.Shared.Bindings.AutoMapper(AssemblyTool.GetAssembly()));

                //DatabaseConfiguration.
                builder.RegisterModule(new KSociety.Base.Infra.Abstraction.Bindings.DatabaseConfiguration(DatabaseOptions));

                //MediatR.
                builder.RegisterModule(new KSociety.Base.Srv.Host.Shared.Bindings.Mediatr());

                //Book.
                builder.RegisterModule(new Bindings.Repository<TContext>());
                builder.RegisterModule(new Bindings.QueryModel());

                //UnitOfWork.
                builder.RegisterModule(new KSociety.Base.Infra.Shared.Bindings.UnitOfWork<TContext>());

                builder.RegisterModule(new KSociety.Base.Infra.Shared.Bindings.DatabaseControl<TContext>());
                builder.RegisterModule(new KSociety.Base.App.Utility.Bindings.DatabaseControlHdlr());

                //CommandHandler.
                builder.RegisterModule(new KSociety.Base.Srv.Host.Shared.Bindings.CommandHdlr(AssemblyTool.GetAssembly()));

                //DatabaseFactory
                builder.RegisterModule(new KSociety.Base.Infra.Shared.Bindings.DatabaseFactory<TContext>());

            }
            catch (Exception ex)
            {
                Console.WriteLine(@"RegisterModule: " + ex.Message + " " + ex.StackTrace);
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<KSociety.Base.Srv.Behavior.Control.DatabaseControl>();
                endpoints.MapGrpcService<KSociety.Base.Srv.Behavior.Control.DatabaseControlAsync>();

                endpoints.MapGrpcService<Srv.Behavior.Command.BookAsync>();

                endpoints.MapGrpcService<Srv.Behavior.Query.QueryAsync>();

                endpoints.MapGrpcService<Srv.Behavior.Query.Model.QueryAsync>();

                //endpoints.MapGrpcService<Srv.Behavior.Query.ListKeyValue.QueryAsync>();

                endpoints.MapGrpcService<Srv.Behavior.Query.List.QueryAsync>();

                endpoints.MapGrpcService<Srv.Behavior.Query.List.GridView.QueryAsync>();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                });
            });
        }
    }
}
