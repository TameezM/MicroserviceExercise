using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RDAP.API.Models;
using RDAP.API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RDAP.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RDAPController : ControllerBase
    {
        private readonly ILogger<RDAPController> _logger;
        private readonly IRDAPService _rdapService;

        public RDAPController(ILogger<RDAPController> logger, IRDAPService rdapService)
        {
            _logger = logger;
            _rdapService = rdapService;
        }
        // GET: api/<RDAPController>
        [HttpGet("{ip}")]
        [ProducesResponseType(typeof(RDAPRspModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<RDAPRspModel>> GetRdapAsync(string ip)
        {
            if (String.IsNullOrEmpty(ip))
            {
                return BadRequest("IP empty");
            }
            var rsp = await _rdapService.GetRDAPDataAsync(ip);
            if (rsp != null)
            {
                return Ok(rsp);
            }
            return NotFound();
        }

     
    }
}
