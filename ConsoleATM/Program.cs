using System;

namespace ConsoleATM
{
    class Program
    {
        static void Main(string[] args)
        {
            Auth atm = new Auth();
            ATMMenu menu = new ATMMenu();
            string state = "login";

            while (true)
            {
                while (state == "login")
                {
                    HandleLoginState(menu, ref state, atm);
                }

                while (state == "main")
                {
                    HandleMainState(menu, ref state, atm);
                }
            }
        }

        static void HandleLoginState(ATMMenu menu, ref string state, Auth atm)
        {
            menu.SetState(state);
            menu.Draw();
            var ch = Console.ReadKey(true).Key;

            switch (ch)
            {
                case ConsoleKey.D0:
                    Console.Clear();
                    break;
                case ConsoleKey.D1:
                    Console.Write("\nPlease enter your PIN: ");
                    string PIN = Console.ReadLine();
                    if (atm.checkPIN(PIN) == false)
                    {
                        Console.Write("\nFailed authentication");
                        break;
                    }
                    else
                    {
                        state = "main";
                    }
                    break;
                case ConsoleKey.D9:
                    Environment.Exit(1);
                    break;
            }
        }

        static void HandleMainState(ATMMenu menu, ref string state, Auth atm)
        {
            menu.SetState(state);
            menu.Draw();
            var ch = Console.ReadKey(true).Key;

            switch (ch)
            {
                case ConsoleKey.D0:
                    Console.Clear();
                    break;
                case ConsoleKey.D1:
                    HandleTransaction(atm.Add, "Enter amount to add: ");
                    break;
                case ConsoleKey.D2:
                    HandleTransaction(atm.Sub, "Enter amount to withdraw: ");
                    break;
                case ConsoleKey.D3:
                    atm.Balance();
                    Console.Write("\n");
                    break;
                case ConsoleKey.D4:
                    state = "login";
                    Console.Clear();
                    break;
            }
        }

        static void HandleTransaction(Func<double, bool> transactionMethod, string prompt)
        {
            Console.Write(prompt);
            string amountStr = Console.ReadLine();
            if (isDouble(amountStr))
            {
                transactionMethod(Convert.ToDouble(amountStr));
            }
            else
            {
                Console.Write("\nInvalid amount");
            }
            Console.Write("\n");
        }

        static bool isDouble(string str)
        {
            double d;
            if (Double.TryParse(str, out d))
            {
                return true;
            }
            return false;
        }
    }
}