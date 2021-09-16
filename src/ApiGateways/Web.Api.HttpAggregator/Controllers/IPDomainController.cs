using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Api.HttpAggregator.Model;
using Web.Api.HttpAggregator.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web.Api.HttpAggregator.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BackendExcController : ControllerBase
    {
        private readonly IGeoIPAddressService _geoIP;
        private readonly IRDAPInfoService _rdap;
        private readonly IDNSInfoService _dnsLookup;
        private readonly IPingInfoService _pingService;
        public BackendExcController(IGeoIPAddressService geoIP, IRDAPInfoService rdap,
            IDNSInfoService dnsLookup, IPingInfoService pingService)
        {
            _geoIP = geoIP;
            _rdap = rdap;
            _dnsLookup = dnsLookup;
            _pingService = pingService;
        }
        // this endpoint is temporarily created to test it urgently as swagger is not present yet.
        [Route("{ipOrDomain}")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(AggregateRspModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<AggregateRspModel>> GetAsync(string ipOrDomain)
        {
            return await GetIpOrDomainData(new ApiInputModel { Address = ipOrDomain, Services = null });
        }
        // POST api/<IPDomainController>
        [Route("GetIpData")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(AggregateRspModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<AggregateRspModel>> GetIpOrDomainData(ApiInputModel model)
        {
            AggregateRspModel rspModel = new AggregateRspModel();
            if (!Utilites.validateAddress(model.Address))
            {
                return BadRequest("Invalid Address. Please send valid address.");
            }
            if (model.Services == null || model.Services?.Count <= 0)
            {
                model.Services = new List<string> { ServiceIdentifiers.GeoIp, ServiceIdentifiers.RDAP, ServiceIdentifiers.ReverseDNS, ServiceIdentifiers.Ping };
            }
            Task<GeoIpResponseModel> geoIpT = null;
            Task<RdapResponseModel> rdapT = null;
            Task<string> dnsT = null;
            Task<string> pingT = null;
            foreach (var service in model.Services)
            {
                if (service.Equals(ServiceIdentifiers.GeoIp, StringComparison.OrdinalIgnoreCase))
                {
                    geoIpT = _geoIP.GetGeoIpInfo(model.Address);
                }
                if (service.Equals(ServiceIdentifiers.RDAP, StringComparison.OrdinalIgnoreCase))
                {
                    rdapT = _rdap.GetRdapInfo(model.Address);
                }
                if (service.Equals(ServiceIdentifiers.ReverseDNS, StringComparison.OrdinalIgnoreCase))
                {
                    dnsT = _dnsLookup.GetDNSInfo(model.Address);
                }
                if (service.Equals(ServiceIdentifiers.Ping, StringComparison.OrdinalIgnoreCase))
                {
                    pingT = _pingService.GetPingInfo(model.Address);
                }

            }
            rspModel.geoIp = geoIpT != null ? await geoIpT : null;
            rspModel.rdapInfo = rdapT != null ? await rdapT : null;
            rspModel.DnsInfo = dnsT != null ? await dnsT : null;
            rspModel.pingInfo = pingT != null ? await pingT : null;
            return Ok(rspModel);
        }

    }
}

