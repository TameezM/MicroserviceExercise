using GeoIP.API.Infrastructure.Exceptions;
using GeoIP.API.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace GeoIP.API.Services
{
    public class GeoIpService : IGeoIpService
    {
        private readonly ILogger<GeoIpService> _logger;
        private readonly HttpClient _httpClient;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="loggerFactory"></param>
        public GeoIpService(ILoggerFactory loggerFactory, HttpClient httpClient)
        {
            _logger = loggerFactory.CreateLogger<GeoIpService>();
            _httpClient = httpClient;
        }
        /// <summary>
        /// deprecated
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public async Task<GeoIpRspModel> GetGeoIpDataAsync(string ip)
        {
            GeoIpRspModel rspModel = new GeoIpRspModel();
                       
                using (var response = await _httpClient.GetAsync(String.Format("http://api.ipstack.com/{0}?access_key=bd3830ebb4ce916ecf51d72f0842c7b4", ip))) //todo to read key from config
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var rsp = response.Content.ReadAsStringAsync().Result;
                        if(rsp==null)
                        {
                            _logger.LogInformation("Problem occured calling geoIp");
                            return null;
                        }
                        rspModel = JsonSerializer.Deserialize(rsp, typeof(GeoIpRspModel)) as GeoIpRspModel;
                        return rspModel;
                    }
                    else
                    {
                        // depending on the response we need to construct rsp object to handle rate limit
                        // etc. for this we need to do little bit R&D on ipstack endpoint specs
                        _logger.LogInformation("Problem occured  calling geoIp", response.Content.ReadAsStringAsync().Result);
                        throw new GeoIPDomainException(response.Content.ReadAsStringAsync().Result);
                    }
                   
                }
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> GetGeoIpDataAsyncv2(string ip)
        {
            return await _httpClient.GetAsync(String.Format("http://api.ipstack.com/{0}?access_key=bd3830ebb4ce916ecf51d72f0842c7b4", ip)); //todo to read key from config
        }
    }
}
