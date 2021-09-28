using System;

namespace EmailExceptionHandlingHW
{
    class Program
    {
        static void Main(string[] args)
        {
            var emailSimulation = new EmailSimulation();

            Console.WriteLine("Normal email simulation:");
            Console.WriteLine(emailSimulation.NormalEmailSimulation());
            Console.WriteLine();

            Console.WriteLine("Invalid email simulation:");
            Console.WriteLine(emailSimulation.InvalidEmailSimulation());
            Console.WriteLine();

            Console.WriteLine("Service unavailable simulation:");
            Console.WriteLine(emailSimulation.ServiceUnvailableSimulation());
            Console.WriteLine();

            Console.WriteLine("Too long email simulation:");
            Console.WriteLine(emailSimulation.TooLongEmailSimulation());

            Console.ReadLine();
        }
    }
}
