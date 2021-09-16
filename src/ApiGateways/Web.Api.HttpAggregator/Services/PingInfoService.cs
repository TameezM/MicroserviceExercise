using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Threading.Tasks;
using Web.Api.HttpAggregator.Config;

namespace Web.Api.HttpAggregator.Services
{
    public class PingInfoService : IPingInfoService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<PingInfoService> _logger;
        private readonly UrlsConfig _urls;
        public PingInfoService(HttpClient httpClient, ILogger<PingInfoService> logger, IOptions<UrlsConfig> config)
        {
            _httpClient = httpClient;
            _logger = logger;
            _urls = config.Value;
        }
        public async Task<string> GetPingInfo(string address)
        {

            var rsp = await _httpClient.GetAsync(UrlsConfig.PingOperations.PingUri(address));
            //TODO To Remove  ReadAsStringAsync from above microservice as it is waited here
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
