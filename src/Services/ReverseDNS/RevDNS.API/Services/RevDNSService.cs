using Microsoft.Extensions.Logging;
using RevDNS.API.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RevDNS.API.Services
{
    public class RevDNSService : IRevDNSService
    {
        private readonly ILogger<RevDNSService> _logger;
        private readonly HttpClient _httpClient;
        public RevDNSService(ILoggerFactory loggerFactory, HttpClient httpClient)
        {
            _logger = loggerFactory.CreateLogger<RevDNSService>();
            _httpClient = httpClient;
        }

        public async Task<string> GetRevDNSDataAsync(string ipOrDomain)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(String.Format("https://www.whoisxmlapi.com/whoisserver/DNSService?apiKey=at_avbMtvuprnh8m1fbvoKsGKa2kGs8W&domainName={0}&type=A&outputFormat=JSON", ipOrDomain)),
            };
            using (var response = await _httpClient.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    var body = await response.Content.ReadAsStringAsync();
                    if (String.IsNullOrEmpty(body))
                    {
                        _logger.LogInformation("Problem occured calling RevDNS service.");
                        return null;
                    }
                    return body;
                }
                else
                {
                    // depending on the response we need to construct rsp object to handle rate limit
                    // etc. for this we need to do little bit R&D on above endpoint specs
                    _logger.LogInformation("Problem occured  calling RevDNS", response.Content.ReadAsStringAsync().Result);
                    throw new RevDNSDomainException(response.Content.ReadAsStringAsync().Result);
                }

            }

        }


    }
}
