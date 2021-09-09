using System;
using BrandNew01.Models;
using BrandNew01.DataContext;
using System.Collections.Generic;
using System.Linq;

namespace BrandNew01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please select menu");
            Console.WriteLine("1.Create accounts");
            Console.WriteLine("2.Deposit");
            Console.WriteLine("3.Transfer");
            Console.WriteLine("-------------------");
            Console.WriteLine("");
            Console.Write("ENTER MENU NUMBER [1/2/3] : ");
            var opt = Console.ReadLine();
            switch (opt)
            {
                case "1":
                    CreateAccount();
                    break;

            }
        }

        public void AccountList()
        {
            using(var context = new ApplicationDbContext())
            {
                List<Accounts> ac = context.tbAccounts.ToList();
                foreach(Accounts acobj in ac)
                {
                    Console.Write(acobj.firstName + ' ' + acobj.lastName);
                }
            }
        }

        static private void CreateAccount()
        {
            Accounts account = new Accounts();
            Console.Write("ENTER FIRST NAME : ");
            account.firstName =  Console.ReadLine();
            Console.Write("ENTER LAST NAME : ");
            account.firstName = Console.ReadLine();
        }
    }
}
