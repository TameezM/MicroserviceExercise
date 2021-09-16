using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevDNS.API.Infrastructure.Exceptions
{
  
    public class RevDNSDomainException : Exception
    {
        public RevDNSDomainException()
        { }

        public RevDNSDomainException(string message)
            : base(message)
        { }

        public RevDNSDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
