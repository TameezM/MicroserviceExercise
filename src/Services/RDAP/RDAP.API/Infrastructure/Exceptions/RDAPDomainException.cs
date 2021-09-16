using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RDAP.API.Infrastructure.Exceptions
{   
    public class RDAPDomainException : Exception
    {
        public RDAPDomainException()
        { }

        public RDAPDomainException(string message)
            : base(message)
        { }

        public RDAPDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
