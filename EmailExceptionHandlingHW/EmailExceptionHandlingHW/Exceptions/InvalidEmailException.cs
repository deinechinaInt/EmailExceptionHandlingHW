using System;

namespace EmailExceptionHandlingHW.Exceptions
{
    public class InvalidEmailException : Exception
    {
        public InvalidEmailException(string recipientEmail):base($"Cannot send email to your friend. Email address \"{recipientEmail}\" is not valid")
        {
        }
    }
}
