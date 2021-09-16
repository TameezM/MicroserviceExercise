using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDAP.API.Models
{    
    // TODO remove from here if we are once it is moved common lib
    public class RDAPRspModel
    {
        public List<string> rdapConformance { get; set; }
        public List<Notice> notices { get; set; }
        public string country { get; set; }
        public List<Event> events { get; set; }
        public string name { get; set; }
        public List<Remark> remarks { get; set; }
        public List<Link> links { get; set; }
        public string type { get; set; }
        public string endAddress { get; set; }
        public string ipVersion { get; set; }
        public string startAddress { get; set; }
        public string objectClassName { get; set; }
        public string handle { get; set; }
        public List<Entity> entities { get; set; }
        public List<Cidr0Cidrs> cidr0_cidrs { get; set; }
        public string port43 { get; set; }
    }
}
