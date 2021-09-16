using RDAP.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RDAP.API.Services
{
   public interface IRDAPService
    {
        Task<RDAPRspModel> GetRDAPDataAsync(string iporDomain);
        Task<HttpResponseMessage> GetRDAPDataAsyncV2(string iporDomain);
    }
}
