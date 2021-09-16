using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDAP.API.Models
{
    public class Entity
    {
        public List<string> roles { get; set; }
        public List<Event> events { get; set; }
        public List<Link> links { get; set; }
        public List<object> vcardArray { get; set; }
        public string objectClassName { get; set; }
        public string handle { get; set; }
    }
}
