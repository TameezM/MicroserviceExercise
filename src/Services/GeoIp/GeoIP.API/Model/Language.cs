using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoIP.API.Model
{
    //todo move to common lib then delete from here
    public class Language
    {
        public string code { get; set; }
        public string name { get; set; }
        public string native { get; set; }
    }
}
