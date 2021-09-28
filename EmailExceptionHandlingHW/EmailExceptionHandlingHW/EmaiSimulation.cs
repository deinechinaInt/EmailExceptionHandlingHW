using System;
using System.Collections.Generic;
using System.Text;
using EmailExceptionHandlingHW.Exceptions;

namespace EmailExceptionHandlingHW
{
    public class EmailSimulation
    {

        public Email EmailToSend { get; set; }

        public bool ServiceUnavailable { get; set; }


        private void ValidateServiceAvailability()
        {
            if (ServiceUnavailable)
            {
                throw new ServiceUnavailableException();
            }
        }

        private void SendEmail()
        {
            EmailToSend.ValidateRecipient();
            ValidateServiceAvailability();
            EmailToSend.ValidateLength();
        }

        public string NormalEmailSimulation()
        {
            EmailToSend = new Email() { RecipientEmail = "test@mail.com", EmailText = "This is ok email" };
            return SendingEmailSimulation();
        }

        public string InvalidEmailSimulation()
        {
            EmailToSend = new Email() { RecipientEmail = "problem.test.com", EmailText = "This is email for invalid email simulation" };
            return SendingEmailSimulation();
        }

        public string ServiceUnvailableSimulation() 
        {
            EmailToSend = new Email() { RecipientEmail = "test@mail.com", EmailText = "This email for service unvailable simulation" };           
            ServiceUnavailable = true;
            return SendingEmailSimulation();
        }

        public string TooLongEmailSimulation()
        {
            EmailToSend = new Email() { RecipientEmail = "test@mail.com", EmailText = "TOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOLOOOOOOOOOOOOOOOONNNNGGG" };
            return SendingEmailSimulation();
        }

        public string SendingEmailSimulation()
        {                       
            var yourEmails = new List<Email>();
            var yourFriendsEmail = new List<Email>();
            var result = string.Empty;
            var rnd = new Random();
            var success = false;
            while (!success)
            {
                try
                {
                    SendEmail();
                    yourFriendsEmail.Add(EmailToSend);
                    success = true;
                }
                catch (InvalidEmailException ex)
                {
                    yourEmails.Add(new Email{ EmailText = ex.Message });
                    success = true;
                }
                catch (ServiceUnavailableException ex)
                {
                    result = string.Format("{0}{1}\n", result, ex.Message);

                    // Simulation of situation that from next trial service may become available but may be not
                    ServiceUnavailable = rnd.Next(0, 2) == 1;          
                }
                catch (LongEmailException ex)
                {
                    result = string.Format("{0}{1}\n", result, ex.Message);
                 
                    var splittedEmails = EmailToSend.SplittedEmails();

                    foreach (var email in splittedEmails)
                    {
                        yourFriendsEmail.Add(email);
                    }

                    success = true;
                }
            }

            if (yourEmails.Count > 0)
            {
                var stringBuilder = new StringBuilder(result);
                stringBuilder.Append("You received new emails:");
                foreach (var email in yourEmails)
                {
                    stringBuilder.AppendFormat("\n{0}", email);
                }
                result = stringBuilder.ToString();
            }

            if (yourFriendsEmail.Count > 0)
            {
                var stringBuilder = new StringBuilder(result);
                stringBuilder.Append("Your friend received new emails:");
                foreach (var email in yourFriendsEmail)
                {
                    stringBuilder.AppendFormat("\n{0}", email);
                }
                result = stringBuilder.ToString();
            }

            return result;
        }

    }
}
