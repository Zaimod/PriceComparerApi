using Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarParts.Controllers
{
    [ApiController]
    [Route("testNlog")]   
    public class TestNlogController : ControllerBase
    {
        private ILoggerManager _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestNlogController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        public TestNlogController(ILoggerManager logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _logger.LogInfo("Here is info."); 
            _logger.LogDebug("Here is debug."); 
            _logger.LogWarn("Here is warn.");
            _logger.LogError("Here is an error.");

            return new string[] { "test1", "test2" };
        }


    }
}
