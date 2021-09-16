using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoIP.API.Infrastructure.Exceptions
{
    
    public class GeoIPDomainException : Exception
    {
        public GeoIPDomainException()
        { }

        public GeoIPDomainException(string message)
            : base(message)
        { }

        public GeoIPDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
