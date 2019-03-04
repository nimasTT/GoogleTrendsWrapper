using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoogleTrendsASPCoreServer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.NodeServices;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GoogleTrendsASPCoreServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestOverTimeController : ControllerBase
    {
        private readonly INodeServices _nodeServices;
        private readonly ILogger<InterestOverTimeController> _logger;
        public InterestOverTimeController(INodeServices nodeServices, ILogger<InterestOverTimeController> logger)
        {
            _nodeServices = nodeServices;
            _logger = logger;
        }

        // GET: api/InterestOverTime/keyword
        [HttpGet("{keyword}", Name = "Get")]
        public async Task<ActionResult<string>> GetAsync(string keyword, [FromQuery]DateTime? startTime, [FromQuery]DateTime? endTime,
            [FromQuery]string geo, [FromQuery]string hl, [FromQuery]int? timeZone, [FromQuery]int? category, [FromQuery]bool? granularTimeResolution)
        {
            string result;
            try
            {
                var request = new Request(keyword, startTime, endTime, geo, hl, timeZone, category, granularTimeResolution);
                result = await _nodeServices.InvokeAsync<string>("./Node/InterestOverTime", request);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
            return Ok(result);
        }

    }
}
