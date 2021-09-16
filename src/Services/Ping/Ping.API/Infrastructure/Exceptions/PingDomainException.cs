using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ping.API.Infrastructure.Exceptions
{
    
    public class PingDomainException : Exception
    {
        public PingDomainException()
        { }

        public PingDomainException(string message)
            : base(message)
        { }

        public PingDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
