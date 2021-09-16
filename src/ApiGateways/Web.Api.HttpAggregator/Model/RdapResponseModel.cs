using ModelsClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.HttpAggregator.Model
{
    public class RdapResponseModel
    {
        public RDAPRspModel rdapInfo { get; set; }
        // we need study the target service to design error model. For now due to time constraints, I'm sending
        // the JsonString.
        public string errorMessage { get; set; }
    }
}
