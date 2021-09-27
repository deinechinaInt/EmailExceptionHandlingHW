using System;

namespace EmailExceptionHandlingHW.Exceptions
{
    public class LongEmailException : Exception
    {
        public LongEmailException(int realLength, int maxLength): base($"Email's text length is {realLength} symbols. Max length allowed is {maxLength} symbols.")
        {

        }
    }
}
