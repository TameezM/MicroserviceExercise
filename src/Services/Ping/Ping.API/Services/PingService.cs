using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ping.API.Services
{
    public class PingService:IPingService
    {
        private readonly ILogger<PingService> _logger;
        private readonly HttpClient _httpClient;
        public PingService(ILoggerFactory loggerFactory, HttpClient httpClient)
        {
            _logger = loggerFactory.CreateLogger<PingService>();
            _httpClient = httpClient;
        }
        /// <summary>
        ///  could not get ping free service hence writing dummy code here 
        ///  we should invoke service REST endpoint
        /// </summary>
        /// <param name="ipOrDomain"></param>
        /// <returns></returns>
        public async Task<string> GetPingDataAsync(string ipOrDomain)
        {
            var t = Task.Run(() => { return "success"; });
              await t;
            return t.Result;
        }
    }
}
