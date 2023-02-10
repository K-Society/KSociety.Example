using KSociety.Base.App.Shared;
using KSociety.Example.Biz.Event;
using KSociety.Example.Biz.Interface;
using Microsoft.Extensions.Logging;

namespace KSociety.Example.App.BizReqHdlr.Biz
{
    public class TestExampleReqHdlr : 
        IRequestHandlerWithResponseAsync<KSociety.Example.App.DtoBiz.Req.Biz.TestExample, KSociety.Example.App.DtoBiz.Res.Biz.TestExample>
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<TestExampleReqHdlr> _logger;
        private readonly IBiz _biz;

        public TestExampleReqHdlr(ILoggerFactory loggerFactory, IBiz biz)
        {
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<TestExampleReqHdlr>();
            _biz = biz;
        }

        public async ValueTask<KSociety.Example.App.DtoBiz.Res.Biz.TestExample> ExecuteAsync(KSociety.Example.App.DtoBiz.Req.Biz.TestExample request, CancellationToken cancellationToken = default)
        {
            var output = new KSociety.Example.App.DtoBiz.Res.Biz.TestExample();

            try
            {
                var result = await _biz.GetTestExampleAsync(new TestExampleEvent("", "", request.TestName, request.TestMessage), cancellationToken).ConfigureAwait(false);
                output.TestName = result.TestName;
                output.TestMessage = result.TestMessage;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "TestExampleReqHdlr ExecuteAsync:  ");
            }

            return output;
        }
    }
}
