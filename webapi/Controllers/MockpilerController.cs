using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using mockpiler;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MockpilerController : ControllerBase
    {
        private readonly ILogger<MockpilerController> _logger;

        public MockpilerController(ILogger<MockpilerController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<string> Post()
        {
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {  
                 string body = await reader.ReadToEndAsync();
                _logger.LogInformation($"mockpile called with body: {JsonConvert.SerializeObject(body)}");
                string result = Mockpiler.StartMockpile(body);
                _logger.LogInformation($"mockpile resulted in: {result}");
                return result;
            }
        }
    }
}
