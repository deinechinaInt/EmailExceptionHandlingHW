using EmailExceptionHandlingHW.Exceptions;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace EmailExceptionHandlingHW
{
    public class Email
    {
        private const string _regularExToValidateRecipient =   @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                   + "@"
                                   + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z"; 

        public const int MaxLength = 50;       

        public string EmailText { get; set; }

        public string RecipientEmail { get; set; }    
        
        public override string ToString()
        {
            return $"Email text: {EmailText}";
        }

        public void ValidateRecipient()
        {
            var recipientEmailRegex = new Regex(_regularExToValidateRecipient);
            if (!recipientEmailRegex.IsMatch(RecipientEmail))
            {
                throw new InvalidEmailException(this);
            }
        }

        public void ValidateLength()
        {
            if(EmailText.Length > MaxLength)
            {
                throw new LongEmailException(EmailText.Length, MaxLength);
            }
        }

        public List<Email> SplittedEmails()
        {
            var splittedEmails = new List<Email>();
            var regexString = @"(?<=\G.{" + MaxLength + "})";
            var splittedTexts = new List<string>(Regex.Split(EmailText, regexString, RegexOptions.Singleline));

            foreach(var text in splittedTexts)
            {
                var newEmail = new Email { EmailText = text, RecipientEmail = RecipientEmail };
              
                splittedEmails.Add(newEmail);
            }
            return splittedEmails;
        }
        
    }
}
