using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.HttpAggregator.Services
{
    public interface IDNSInfoService
    {
        Task<string> GetDNSInfo(string domainName);
    }
}
