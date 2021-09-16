using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDAP.API.Models
{
    public class Link
    {
        public string value { get; set; }
        public string rel { get; set; }
        public string href { get; set; }
        public string type { get; set; }
    }
}
