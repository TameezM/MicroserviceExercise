using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Web.Api.HttpAggregator.Config;
using ModelsClassLib;
using System.Text.Json;
using Web.Api.HttpAggregator.Model;
using System.Net.Http;
using Microsoft.Extensions.Logging;

namespace Web.Api.HttpAggregator.Services
{
    public class DNSInfoService : IDNSInfoService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<DNSInfoService> _logger;
        private readonly UrlsConfig _urls;
        public DNSInfoService(HttpClient httpClient, ILogger<DNSInfoService> logger, IOptions<UrlsConfig> config)
        {
            _httpClient = httpClient;
            _logger = logger;
            _urls = config.Value;
        }
        public async Task<string> GetDNSInfo(string domainName)
        {
            var rsp = await _httpClient.GetAsync(UrlsConfig.ReverseDNSOperations.GetReverseDNSUri(domainName));
            string responseModel = null;
            if (rsp.IsSuccessStatusCode)
            {
                var content = rsp.Content.ReadAsStringAsync().Result;
                // TODO in some case though the status code is success, the model may not always be below one. hence need to handle this
                responseModel = !string.IsNullOrEmpty(content) ? content : null;
            }
            else
            {
                responseModel = rsp.Content.ReadAsStringAsync().Result;
            }
            return responseModel;
        }
    }
}
