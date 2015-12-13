using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ConsoleATM
{
    class Program
    {
        static void Main(string[] args)
        {
            //Entry point for the main program.  Initial classes and state are setup.
            Auth atm = new Auth();  //This class handles authentication and authorization for funds actions.
            ATMMenu menu = new ATMMenu();  //This class handles the menu based on the current state of the object.
            string state = "login";  //default state at runtime.

            while (true)  //main program loop.  should remain continuous to support changing states for the menu levels.
            {
                while (state == "login")  //this should be the default state. it decides what an unauthenticated user sees at the logon prompt.
                {
                    menu.SetState(state);
                    menu.Draw();
                    var ch = Console.ReadKey(true).Key;

                    switch (ch)  //base on the user's keystroke, different menus items are executed.
                    {
                        case ConsoleKey.D0:
                            Console.Clear();
                            break;

                        case ConsoleKey.D1:
                            Console.Write("\nPlease enter your PIN: ");
                            string PIN = Console.ReadLine();
                            if (atm.checkPIN(PIN) == false)  //failed authentication.
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
                            System.Environment.Exit(1);  //gracefully terminate with error level 1.
                            break;
                    }
                }

                while (state == "main")  //this is the menu state for authenticated users and provides access to a larger series of actions
                {
                    menu.SetState(state);
                    menu.Draw();
                    var ch = Console.ReadKey(true).Key;

                    switch (ch)
                    {
                        case ConsoleKey.D0:
                            Console.Clear();
                            break;

                        case ConsoleKey.D1: //add money to the account
                            Console.Write("Enter amount to add: ");
                            string amtadd = Console.ReadLine();
                            if (isDouble(amtadd)) //to verify that the input is actually a double
                            {
                                atm.Add(Convert.ToDouble(amtadd));  //pass the input to the atm object where it will receive further vetting
                            }
                            else
                            {
                                Console.Write("\nInvalid amount");
                            }
                            Console.Write("\n");
                            break;

                        case ConsoleKey.D2:  //subtract money from the account
                            Console.Write("Enter amount to withdraw: ");
                            string amtsub = Console.ReadLine();
                            if (isDouble(amtsub))   //to verify that the input is actually a double
                            {
                                atm.Sub(Convert.ToDouble(amtsub));  //pass the input to the atm object where it will receive further vetting
                            }
                            else
                            {
                                Console.Write("\nInvalid amount");
                            }
                            Console.Write("\n");
                            break;

                        case ConsoleKey.D3:  //prints out the current balance
                            atm.Balance();
                            Console.Write("\n");
                            break;

                        case ConsoleKey.D4:  //returns to the logon screen
                            state = "login";
                            Console.Clear();
                            break;
                    }

                    break;
                }
            }
        }

        //function to test string input to see if it can be used as a double data type
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
