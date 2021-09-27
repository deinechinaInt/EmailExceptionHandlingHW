using EmailExceptionHandlingHW.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmailExceptionHandlingHW
{
    class Program
    {
        static void Main(string[] args)
        {
            var yourEmails = new List<Email>();
            var yourFriendsEmail = new List<Email>();

            var okEmail = new Email() { RecipientEmail = "test@mail.com", EmailText = "This is ok email" };
            var invalidEmail = new Email() { RecipientEmail = "problem.test.com", EmailText = "Problem with email validation" };
            var tooLongEmail = new Email() { RecipientEmail = "test@mail.com", EmailText = "TOOOOOOOOOOOOOOOOOOOOOOOOOOOOOLOOOOOOOOOOOOOOOONNNNGGG" };

            var testExamples = new List<EmailSimulation>
            {
                //new EmailSimulation(okEmail),              

                // Uncomment to test invalid email
                //new EmailSimulation(invalidEmail),
                
                // Uncomment to test service unavailable
                //new EmailSimulation(okEmail){ ServiceUnavailable = true},

                 // Uncomment to test too long email
                new EmailSimulation(tooLongEmail)
            };

            foreach(var test in testExamples)
            {
                var success = false;
                while (!success)
                {
                    try 
                    {
                        test.SendEmail();
                        yourFriendsEmail.Add(test.EmailToSend);
                        success = true;
                    }
                    catch(InvalidEmailException ex)
                    {
                        yourEmails.Add(new Email(ex.Message));
                        success = true;
                    }
                    catch(ServiceUnavailableException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine("Press \"y\" if you want to retry! Else press \"n\" ");
                        success = Console.ReadLine() != "y";
                    }
                    catch(LongEmailException ex)
                    {
                        Console.WriteLine(string.Format("{0} Email will be splitted.",ex.Message));

                        var splittedEmails = test.EmailToSend.SplittedEmails();

                        foreach (var email in splittedEmails )
                        {
                            yourFriendsEmail.Add(email);
                        }
                      
                        success = true;
                    }
                }
            }


            if (yourEmails.Count() > 0)
            {
                Console.WriteLine();
                Console.WriteLine("You have new emails:");
                foreach(var email in yourEmails)
                {
                    Console.WriteLine(email);
                }

                Console.WriteLine();
            }

            if (yourFriendsEmail.Count() > 0)
            {
                Console.WriteLine("Your friend's new emails:");
                foreach (var email in yourFriendsEmail)
                {
                    Console.WriteLine(email);
                }
            }

            Console.ReadLine();
        }
    }
}
