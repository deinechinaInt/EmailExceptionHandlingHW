using System;

namespace EmailExceptionHandlingHW.Exceptions
{
    public class InvalidEmailException : Exception
    {
        public InvalidEmailException(Email email) : base($"Cannot send email (Content: {email.EmailText}) to your friend.\nEmail address \"{email.RecipientEmail}\" is not valid")
        {
        }
    }
}
