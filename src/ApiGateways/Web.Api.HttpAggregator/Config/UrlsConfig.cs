using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.HttpAggregator.Config
{
    public class UrlsConfig
    {
        public class GeoIPOperations
        {
            public static string GetGeoIpUri(string address) => $"https://localhost:44318/api/v1/GeoIP/{address}";
        }

        public class RDAPOperations
        {
            public static string GetRDAPUri(string address) => $"https://localhost:44382/api/v1/RDAP/{address}";
        }
        public class ReverseDNSOperations
        {
            // returning bbc.com as ip address is throwing error. need to find free revdns service to get info
            public static string GetReverseDNSUri(string address) => $"https://localhost:44363/api/v1/RevDNS/bbc.com";
        }

        public class PingOperations
        {
            public static string PingUri(string address) => $"https://localhost:44334/api/v1/Ping/{address}";
        }
    }
}
