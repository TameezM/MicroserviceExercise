using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.HttpAggregator.Model;

namespace Web.Api.HttpAggregator.Services
{
    public interface IGeoIPAddressService
    {
        Task<GeoIpResponseModel> GetGeoIpInfo(string address);
    }
}
