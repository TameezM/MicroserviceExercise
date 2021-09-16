using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using GeoIP.API.Model;
using GeoIP.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GeoIP.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GeoIPController : ControllerBase
    {
        private readonly ILogger<GeoIPController> _logger;
        private readonly IGeoIpService _geoIpService;
        
        public GeoIPController(ILogger<GeoIPController> logger, IGeoIpService geoIpService)
        {
            _logger = logger;
            _geoIpService = geoIpService;
        }
        [HttpGet("{address}")]
        [ProducesResponseType(typeof(GeoIpRspModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        //[ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        //[ProducesResponseType((int)HttpStatusCode.Accepted)] // thinking of rate throttling
        public async Task<ActionResult<GeoIpRspModel>> GetGeoIPAsync(string address)
        {
            if (String.IsNullOrEmpty(address))
            {
                return BadRequest("IP or Domain is empty");
            }
            var rsp = await _geoIpService.GetGeoIpDataAsync(address);
            if(rsp!=null)
            {
                return Ok(rsp);
            }
            return NotFound();
        }
      
    }
}
