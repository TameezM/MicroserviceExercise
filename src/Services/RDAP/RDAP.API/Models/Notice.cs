using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDAP.API.Models
{
    public class Notice
    {
        public string title { get; set; }
        public List<string> description { get; set; }
        public List<Link> links { get; set; }
    }
}
