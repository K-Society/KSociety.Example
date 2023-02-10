using Autofac;
using KSociety.Example.Biz.Interface;
using Microsoft.Extensions.Logging;

namespace KSociety.Example.Biz.Class
{
    public class Startup : IStartable
    {
        private readonly ILogger<Startup> _logger;
        private readonly ILoggerFactory _loggerFactory;
        private readonly IBiz _biz;

        public Startup(
            ILoggerFactory loggerFactory,
            IBiz biz
        )
        {
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory.CreateLogger<Startup>();

            _biz = biz;

            _logger.LogInformation("KSociety.Example.Biz startup: ");
        }

        public void Start()
        {
            _logger.LogTrace("KSociety.Example.Biz staring...");

            _biz.LoadEventBus();
        }
    }
}
