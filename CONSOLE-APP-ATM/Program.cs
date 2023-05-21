using System;

namespace ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            Cardholder user = new Cardholder("Luke", 2023, 100.00f);
            Console.WriteLine("Hi " + user.Name + ", please enter your PIN:");
            int input = int.Parse(Console.ReadLine());

            if (input == user.PIN)
            {
                bool exitRequested = false;

                while (!exitRequested)
                {
                    float balance = (user.GetBalance());
                    Console.WriteLine("Options:");
                    Console.WriteLine("1: Show Balance");
                    Console.WriteLine("2. Deposit");
                    Console.WriteLine("3. Withdraw");
                    Console.WriteLine("4. Exit");

                    string selected = Console.ReadLine();

                    switch (selected)
                    {
                        case "1":
                            Balance(user);
                            break;
                        case "2":
                            Deposit(user);
                            break;
                        case "3":
                            Withdraw(user);
                            break;
                        case "4":
                            exitRequested = true;
                            break;
                        default:
                            Console.WriteLine("Invalid Option");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Incorrect PIN");
                Console.ReadLine();
            }
        }

        // Functions to display dialog to ATM console

        static void Balance(Cardholder user)
        {
            Console.WriteLine("Balance: " + user.GetBalance().ToString("F2"));
            Console.WriteLine("Options:");
            Console.WriteLine("1. Go Back");
            Console.WriteLine("2. Exit");

            string selected = Console.ReadLine();

            if (selected == "1")
            {
                return; // Go back to the options menu
            }
            else if (selected == "2")
            {
                Exit(); // Exit the program
            }
            else
            {
                Console.WriteLine("Invalid option");
                Console.ReadLine();
            }
        }

        static void Deposit(Cardholder user)
        {
            Console.WriteLine("Please enter the amount you want to deposit:");
            float amountDeposited = float.Parse(Console.ReadLine());
            user.Deposit(amountDeposited);
            Console.WriteLine("Your new balance is: " + user.GetBalance().ToString("F2"));

            Console.WriteLine("Options:");
            Console.WriteLine("1. Go Back");
            Console.WriteLine("2. Exit");

            string selected = Console.ReadLine();

            if (selected == "1")
            {
                return; // Go back to the options menu
            }
            else if (selected == "2")
            {
                Exit(); // Exit the program
            }
            else
            {
                Console.WriteLine("Invalid option");
                Console.ReadLine();
            }
        }

        static void Withdraw(Cardholder user)
        {
            float userBalance = user.GetBalance();
            Console.WriteLine("Please enter the amount you would like to withdraw:");
            float amountWithdrawn = float.Parse(Console.ReadLine());

            if (amountWithdrawn > userBalance)
            {
                Console.WriteLine("You can't withdraw more than your balance.");
                Console.WriteLine("Balance: " + userBalance);
                Console.ReadLine();
                return;
            }

            user.Withdraw(amountWithdrawn);
            Console.WriteLine("Your new balance is: " + user.GetBalance().ToString("F2"));

            Console.WriteLine("Options:");
            Console.WriteLine("1. Go Back");
            Console.WriteLine("2. Exit");

            string selected = Console.ReadLine();

            if (selected == "1")
            {
                return; // Go back to the options menu
            }
            else if (selected == "2")
            {
                Exit(); // Exit the program
            }
            else
            {
                Console.WriteLine("Invalid option");
                Console.ReadLine();
            }
        }

        static void Exit()
        {
            Console.WriteLine("Exiting the program...");
            Environment.Exit(0);
        }
    }

    public class Cardholder
    {
        public string Name { get; private set; }
        public int PIN { get; private set; }
        public float Balance { get; private set; }

        public Cardholder(string name, int pin, float balance)
        {
            Name = name;
            PIN = pin;
            Balance = balance;
        }

        public float GetBalance()
        {
            return Balance;
        }

        public void Deposit(float deposited)
        {
            Balance += deposited;
        }

        public void Withdraw(float withdrawn)
        {
            Balance -= withdrawn;
        }
    }
}
