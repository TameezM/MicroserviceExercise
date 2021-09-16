using GeoIP.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GeoIP.API.Services
{
    public interface IGeoIpService
    {
        Task<GeoIpRspModel> GetGeoIpDataAsync(string ip); 
        Task<HttpResponseMessage> GetGeoIpDataAsyncv2(string ip);
    }
}
