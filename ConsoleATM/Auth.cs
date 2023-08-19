using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleATM
{
    class Auth
    {
        //Class for handling authentication and transactions to and from the bank account
        private string secret;
        private double balance = 0;  //the user begins with a 0 balance

        public Auth()
        {
            // Read the PIN from the configuration file
            try
            {
                secret = ConfigurationManager.AppSettings["PIN"];
                if (string.IsNullOrEmpty(secret))
                {
                    throw new Exception("PIN not found in configuration.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading PIN from configuration: {ex.Message}");
                Environment.Exit(1); // Exit the application if the PIN cannot be read
            }
        }

        public bool checkPIN(string PIN)
        {
            if (PIN == secret)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Balance() //print out the current balance of the account
        {
            Console.WriteLine("\nBalance: $"+balance);
        }

        public bool Add(double amount)  //adds money to the account; validates that the amount is > 0 before allowing it
        {
            if (amount <= 0)
            {
                Console.WriteLine("\nInvalid transaction amount.");

                return false;
            }
            else
            {
                balance += amount;
            }
            return true;
        }

        public bool Sub(double amount)  //subtracts money from the account; validates that the value is positive and won't take them below $-35
        {
            if (balance < -35)
            {
                Console.WriteLine("\nInsufficient funds.");
                return false;
            }
            else if (balance - amount < -35)
            {
                Console.WriteLine("\nInsufficient funds.");
                return false;
            }
            else if (amount <= 0)
            {
                Console.WriteLine("\nInvalid transaction amount.");
            }
            else
            {
                balance -= amount;
                Console.WriteLine("\nAmount withdrawn.");
            }
            return true;
        }
    }
}
