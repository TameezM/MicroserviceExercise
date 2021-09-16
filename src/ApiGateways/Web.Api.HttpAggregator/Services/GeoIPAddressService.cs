using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Web.Api.HttpAggregator.Config;
using ModelsClassLib;
using System.Text.Json;
using Web.Api.HttpAggregator.Model;

namespace Web.Api.HttpAggregator.Services
{
    public class GeoIPAddressService : IGeoIPAddressService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<GeoIPAddressService> _logger;
        private readonly UrlsConfig _urls;
        public GeoIPAddressService(HttpClient httpClient, ILogger<GeoIPAddressService> logger, IOptions<UrlsConfig> config)
        {
            _httpClient = httpClient;
            _logger = logger;
            _urls = config.Value;
        }
        public async Task<GeoIpResponseModel> GetGeoIpInfo(string address)
        {
            var rsp = await _httpClient.GetAsync(UrlsConfig.GeoIPOperations.GetGeoIpUri(address));
            GeoIpResponseModel responseModel = null;
            responseModel = new GeoIpResponseModel();
            if (rsp.IsSuccessStatusCode)
            {
                var content = rsp.Content.ReadAsStringAsync().Result;
                // TODO in some case though the status code is success, the model may not always be below one. hence need to handle this
                var geoIpInfo = !string.IsNullOrEmpty(content) ? JsonSerializer.Deserialize(content, typeof(GeoIpRspModel)) as GeoIpRspModel : null;
                if (geoIpInfo != null)
                {
                    responseModel.GeoIpModel = geoIpInfo;
                }
                else
                {
                    responseModel.GeoIpModel = null;
                }
            }
            else
            {
                responseModel.errorMessage = rsp.Content.ReadAsStringAsync().Result;
            }

            return responseModel;
        }
    }
}
