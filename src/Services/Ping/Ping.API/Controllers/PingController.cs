using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ping.API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ping.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        // GET: api/<PingController>
        private readonly ILogger<PingController> _logger;
        private readonly IPingService _pingService;
        public PingController(ILogger<PingController> logger, IPingService pingService)
        {
            _logger = logger;
            _pingService = pingService;
        }
        // GET api/<PingController>/5
        [HttpGet("{ipOrDomain}")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<string>> GetPingAsync(string ipOrDomain)
        {
            if (String.IsNullOrEmpty(ipOrDomain))
            {
                return BadRequest("IP or Domain empty");
            }
            var rsp = await _pingService.GetPingDataAsync(ipOrDomain);
            if (rsp != null)
            {
                return Ok(rsp);
            }
            return NotFound();
        }

    }
}
