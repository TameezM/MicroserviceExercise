using Microsoft.Extensions.Logging;
using RDAP.API.Infrastructure.Exceptions;
using RDAP.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace RDAP.API.Services
{
    public class RDAPService : IRDAPService
    {
        private readonly ILogger<RDAPService> _logger;
        private readonly HttpClient _httpClient;
        public RDAPService(ILoggerFactory loggerFactory, HttpClient httpClient)
        {
            _logger = loggerFactory.CreateLogger<RDAPService>();
            _httpClient = httpClient;
        }
        public async Task<RDAPRspModel> GetRDAPDataAsync(string ipOrDomain)
        {
            RDAPRspModel rspModel = new RDAPRspModel();

            // this service only accepting ip not domain. it throws badrequest if domain is passed. need to sort this out.
            using (var response = await _httpClient.GetAsync(String.Format("https://rdap.apnic.net/ip/{0}", ipOrDomain))) //todo to read key from config
            {
                if (response.IsSuccessStatusCode)
                {
                    var rsp = response.Content.ReadAsStringAsync().Result;
                    if (rsp == null)
                    {
                        _logger.LogInformation("Problem occured calling apnic service.");
                        return null;
                    }
                    rspModel = JsonSerializer.Deserialize(rsp, typeof(RDAPRspModel)) as RDAPRspModel;
                    return rspModel;
                }
                else
                {
                    // depending on the response we need to construct rsp object to handle rate limit
                    // etc. for this we need to do little bit R&D on ipstack endpoint specs
                    _logger.LogInformation("Problem occured  calling RDAP", response.Content.ReadAsStringAsync().Result);
                    throw new RDAPDomainException(response.Content.ReadAsStringAsync().Result);
                }

            }
        }
        public async Task<HttpResponseMessage> GetRDAPDataAsyncV2(string ipOrDomain)
        {
            // this service only accepting ip not domain. it throws badrequest if domain is passed. need to sort this out.
            return await _httpClient.GetAsync(String.Format("https://rdap.apnic.net/ip/{0}", ipOrDomain)); //todo to read key from config
            
        }
    }
}
