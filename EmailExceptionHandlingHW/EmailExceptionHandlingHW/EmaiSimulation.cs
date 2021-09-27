using EmailExceptionHandlingHW.Exceptions;

namespace EmailExceptionHandlingHW
{
    public class EmailSimulation
    {
        
        public Email EmailToSend { get; set; }

        public bool ServiceUnavailable { get; set; }     

        public EmailSimulation(Email email)
        {
            EmailToSend = email;
        }

        private void ValidateServiceAvailability()
        {
            if (ServiceUnavailable)
            {
                throw new ServiceUnavailableException();
            }
        }
       
        public void SendEmail()
        {
            EmailToSend.ValidateRecipient();
            ValidateServiceAvailability();
            EmailToSend.ValidateLength();
        }

    }
}
