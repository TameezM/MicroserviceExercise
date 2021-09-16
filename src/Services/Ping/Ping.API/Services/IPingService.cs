using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ping.API.Services
{
    public interface IPingService
    {
        Task<string> GetPingDataAsync(string ipOrDomain);
    }
}
