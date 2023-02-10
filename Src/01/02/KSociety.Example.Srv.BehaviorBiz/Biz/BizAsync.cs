using Autofac;
using KSociety.Base.Srv.Shared.Interface;
using KSociety.Example.Srv.ContractBiz.Biz;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc;

namespace KSociety.Example.Srv.BehaviorBiz.Biz
{
    public class BizAsync : IBizAsync
    {
        private readonly ILoggerFactory _loggerFactory;
        private static ILogger<BizAsync> _logger;
        private readonly IComponentContext _componentContext;
        private readonly ICommandHandlerAsync _commandHandlerAsync;

        public BizAsync(
            ILoggerFactory loggerFactory,
            IComponentContext componentContext,
            ICommandHandlerAsync commandHandlerAsync
        )
        {
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<BizAsync>();
            _componentContext = componentContext;
            _commandHandlerAsync = commandHandlerAsync;
        }

        public async ValueTask<App.DtoBiz.Res.Biz.TestExample> GetTestExampleAsync(App.DtoBiz.Req.Biz.TestExample request, CallContext context = default)
        {
            return await _commandHandlerAsync.ExecuteWithResponseAsync<App.DtoBiz.Req.Biz.TestExample, App.DtoBiz.Res.Biz.TestExample>(_loggerFactory, _componentContext, request, context.CancellationToken);
        }
    }
}
