using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ModelsClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Web.Api.HttpAggregator.Config;
using Web.Api.HttpAggregator.Model;

namespace Web.Api.HttpAggregator.Services
{
    public class RDAPInfoService : IRDAPInfoService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<RDAPInfoService> _logger;
        private readonly UrlsConfig _urls;
        public RDAPInfoService(HttpClient httpClient, ILogger<RDAPInfoService> logger, IOptions<UrlsConfig> config)
        {
            _httpClient = httpClient;
            _logger = logger;
            _urls = config.Value;
        }
        public async Task<RdapResponseModel> GetRdapInfo(string address)
        {

            var rsp = await _httpClient.GetAsync(UrlsConfig.RDAPOperations.GetRDAPUri(address));
            //TODO To Remove  ReadAsStringAsync from above microservice as it is awaited here
            RdapResponseModel responseModel = new RdapResponseModel();
            if (rsp.IsSuccessStatusCode)
            {
                var content = rsp.Content.ReadAsStringAsync().Result;
                // TODO in some case though the status code is success, the model may not always be below one. hence need to handle this
                var info = !string.IsNullOrEmpty(content) ? JsonSerializer.Deserialize(content, typeof(RDAPRspModel)) as RDAPRspModel : null;
                if (info != null)
                {
                    responseModel.rdapInfo = info;
                }
                else
                {
                    responseModel.rdapInfo = null;
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
