using Microsoft.AspNetCore.Mvc;
using Yumyum.Infrastructure.Logger;

namespace Yumyum.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoggerController : ControllerBase
    {
        private ILoggerManager _logger;
        public LoggerController(ILoggerManager logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IEnumerable<string> Get()
        {
            _logger.LogInfo("Here is info message from our values controller.");
            _logger.LogDebug("Here is debug message from our values controller.");
            _logger.LogWarn("Here is warn message from our values controller.");
            _logger.LogError("Here is an error message from our values controller.");
            return new string[] { "value1", "value2" };
        }
    }
}