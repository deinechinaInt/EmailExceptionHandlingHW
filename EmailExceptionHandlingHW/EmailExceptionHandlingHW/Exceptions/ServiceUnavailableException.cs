using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailExceptionHandlingHW.Exceptions
{
    public class ServiceUnavailableException :Exception
    {
        public override string Message => "Service is unavailable.";
    }
}
