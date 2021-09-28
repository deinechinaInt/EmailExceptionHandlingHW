using System;

namespace EmailExceptionHandlingHW.Exceptions
{
    public class ServiceUnavailableException :Exception
    {
        public override string Message => "Service is unavailable. Retrying...";
    }
}
