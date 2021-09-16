using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RevDNS.API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RevDNS.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RevDNSController : ControllerBase
    {
        private readonly ILogger<RevDNSController> _logger;
        private readonly IRevDNSService _revDNSService;
        public RevDNSController(ILogger<RevDNSController> logger, IRevDNSService revDNSService)
        {
            _logger = logger;
            _revDNSService = revDNSService;
        }
        // GET: api/<RevDNSController>
        [HttpGet("{ipOrDomain}")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<string>> GetRevDNSAsync(string ipOrDomain)
        {
            if (String.IsNullOrEmpty(ipOrDomain))
            {
                return BadRequest("IP or Domain empty");
            }
            var rsp = await _revDNSService.GetRevDNSDataAsync(ipOrDomain);
            if (rsp != null)
            {
                return Ok(rsp);
            }
            return NotFound();
        }

      
    }
}
