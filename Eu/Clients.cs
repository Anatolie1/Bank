using System;
using System.Collections.Generic;
using System.Text;

namespace Eu
{
    class Clients
    {
        private static Dictionary<string, double> jean = new Dictionary<string, double>() { { "curentAccount", 1458.23 }, { "savingAccount", 15000.35 }};

        public static void EnterClientAccount(string name)
        {
            Console.WriteLine("{0}, welcome on your personal account", name);
            Console.WriteLine("What operation do you want to do ?");
            string option = Console.ReadLine();
            Operation(option);
        }
        public static void Operation(string operation)
        {
            string option = operation;
            switch(option)
            {
                case "trm":
                    TransferMoney();
                    break;
                case "check":
                    CheckMoney();
                    break;

                default:
                    Console.WriteLine("Your operation is not recognized");
                    break;
            }
        }
        public static void TransferMoney()
        {
            Console.WriteLine("Chose debit account : curentAccount or savingAccount ");
            string debit = Console.ReadLine();
            Console.WriteLine("Chose credit account : curentAccount or savingAccount ");
            string credit = Console.ReadLine();
            Console.WriteLine("Give the amount : ");
            double amount = Convert.ToDouble(Console.ReadLine());
            if (debit == "curentAccount")
            {
                jean["curentAccount"] = jean["curentAccount"] - amount;
                jean["savingAccount"] = jean["savingAccount"] + amount;               
            }
            else
            {
                jean["savingAccount"] = jean["savingAccount"] - amount;
                jean["curentAccount"] = jean["curentAccount"] + amount;                
            }
            Console.WriteLine("What is your next action ?");
            string option = Console.ReadLine();
            Operation(option);
        }
        public static void CheckMoney()
        {
            foreach(KeyValuePair<string, double> item in jean)
            {
                Console.WriteLine("{0} has {1} euros", item.Key, item.Value);
            }
            Console.WriteLine("What is your next action ?");
            string option = Console.ReadLine();
            Operation(option);
        }
    }
}
