using System;

namespace ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            string user = "Luke";
            int pin = 2023;
            double amount = 0.00;

            Console.WriteLine("Hi " + user + ": Please enter your PIN number");

            string checkPin = Console.ReadLine();

            if (checkPin == pin.ToString())
            {
                Console.WriteLine("Balance: " + amount.ToString("F2"));
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Incorrect PIN");
            }

            Console.ReadLine(); // Keeps the console window open
        }
    }
}
