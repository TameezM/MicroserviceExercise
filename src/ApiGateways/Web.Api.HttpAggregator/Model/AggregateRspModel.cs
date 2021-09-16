using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.HttpAggregator.Model
{
    public class AggregateRspModel
    {
        public GeoIpResponseModel geoIp { get; set; }        
        public RdapResponseModel rdapInfo { get; set; }
        public string pingInfo { get; set; }// TODO investigate free endpoint and write models for it
        public string DnsInfo { get; set; }// TODO investigate free reverse endpoint and write models for it
                                           // for now as the response model from dns lookup is big, we need to 
                                           // trim unwanted prop.
    }
}
