using System;
using System.Collections.Generic;
using System.Text;

namespace Eu
{
    abstract class Authentification
    {
        protected static Dictionary<string, int> login = new Dictionary<string, int>() { { "Counselor", 1234 }, { "Jean", 2345 }, { "Marie", 3456 }, { "Dominique", 4567 } };

        public static void OpenApplication()
        {
            Console.WriteLine("Welcome on Bank application");
            EnterLogin(3);
        }
        public static void EnterLogin(int i)
        {
            if (i >= 1)
            {
                Console.WriteLine("Enter your name : ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter your password : ");
                int password = Convert.ToInt32(Console.ReadLine());
                CheckLogin(name, password);
            }
            else
            {
                Console.WriteLine("Your account is locked, Please contact security bank service");
            }

        }
        static int counter = 3;
        public static void CheckLogin(string name, int password)
        {
            if (login[name] == password)
            {
                Console.WriteLine("Hello {0} ", name);
                if (name == "Counselor")
                {
                    Counselor.OpenClientManager();
                }
                else
                {
                    Clients.EnterClientAccount(name);
                }
            }
            else
            {
                counter--;
                Console.WriteLine("Error of authentification, you have {0} more attempts", counter);
                EnterLogin(counter);
            }
        }
    }
}
