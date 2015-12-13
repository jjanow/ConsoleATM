using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleATM
{
    class ATMMenu
    {
        //class to manage the menu depending on how the state of instantiated objects is set
        private string state = "login";  //defaults to the login state and menu

        public void SetState (string st)  //used to swap the state between the two allowed values
        {
            if (st == "login" || st == "main")
            {
                state = st;
            }
        }

        public void Draw()  //draws the menu for whichever state is active
        {
            if (state == "login")
            {
                DrawLogin();
            }
            else if (state == "main")
            {
                DrawMain();
            }
        }

        void DrawLogin()  //draws the login menu
        {
            Console.WriteLine("\n0. Clear screen");
            Console.WriteLine("1. Sign In");
            Console.WriteLine("9. Exit");
        }

        void DrawMain()  //draws the main menu
        {
            Console.WriteLine("\n0. Clear screen");
            Console.WriteLine("1. Add funds");
            Console.WriteLine("2. Withdraw funds");
            Console.WriteLine("3. Review balance");
            Console.WriteLine("4. Logoff");
        }
    }
}
