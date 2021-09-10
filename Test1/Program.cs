using System;
using Test1.Models;
using Test1.DataContext;
using System.Collections.Generic;
using System.Linq;

namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            StartSystem();
        }

        static void StartSystem()
        {
            Console.WriteLine("Please select menu");
            Console.WriteLine("1.Create accounts");
            Console.WriteLine("2.Deposit");
            Console.WriteLine("3.Transfer");
            Console.WriteLine("--------------------");
            Console.WriteLine("");
            Console.Write("ENTER MENU NUMBER [1/2/3] : ");
            var opt = Console.ReadLine().ToUpper();
            switch (opt)
            {
                case "1":
                    CreateAccount();
                    break;
                case "2":
                    Deposit();
                    break;
                case "3":
                    Transfer();
                    break;
                case "LIST":
                    AccountList();
                    break;
                default:
                    StartSystem();
                    break;
            }
        }

        static private void AccountList()
        {
            using (var context = new ApplicationDbContext())
            {
                List<Accounts> ac = context.tbAccounts.ToList();
                foreach (Accounts acobj in ac)
                {
                    Console.WriteLine($"FIRSTNAME : {acobj.firstName}");
                    Console.WriteLine($"LASTNAME : {acobj.lastName}");
                    Console.WriteLine($"IBAN : {acobj.iban}");
                    Console.WriteLine($"BALANCE : {acobj.balance.ToString("0.00")}");
                    Console.WriteLine("--------------------");
                }
            }
            StartSystem();
        }
        static private Accounts GetAccountByIBAN(string iban)
        {
            Accounts account = new Accounts();
            using (var context = new ApplicationDbContext())
            {
                account = context.tbAccounts.SingleOrDefault(x => x.iban == iban);
            }

            return account;
        }

        #region CreateAccount
        static private void CreateAccount()
        {
            Accounts account = new Accounts();
            Console.Write("ENTER FIRSTNAME : ");
            account.firstName = Console.ReadLine().Replace(" ", ""); ;
            Console.Write("ENTER LASTNAME : ");
            account.lastName = Console.ReadLine().Replace(" ", ""); ;
            Console.Write("ENTER IBAN : ");
            account.iban = Console.ReadLine().Replace(" ", ""); ;
            Console.WriteLine();
            Console.WriteLine("INFORMATION");
            Console.WriteLine($"FIRSTNAME : {account.firstName}");
            Console.WriteLine($"LASTNAME : {account.lastName}");
            Console.WriteLine($"IBAN : {account.iban}");
            Console.WriteLine("PLEASE CONFIRM TO CREATE ACCOUNT [Y/N] : ");
            var cmf = Console.ReadLine().ToUpper();
            if (cmf == "Y")
            {
                SaveAccount(account);
            }
        }

        static private void SaveAccount(Accounts account)
        {
            if (string.IsNullOrWhiteSpace(account.firstName) && string.IsNullOrWhiteSpace(account.lastName) && string.IsNullOrWhiteSpace(account.iban))
            {
                Console.WriteLine("FIRSTNAME ,LASTNAME AND IBAN CANNOT BE EMPTY PLEASE TRY AGAIN!");
            }
            else
            {
                try
                {
                    using (var context = new ApplicationDbContext())
                    {
                        List<Accounts> duplicatedIBAN = context.tbAccounts.Where(x => x.iban == account.iban).ToList();

                        if (duplicatedIBAN.Count > 0)
                        {
                            Console.WriteLine("IBAN IS DUPLICATED PLEASE TRY AGAIN!");
                            Console.WriteLine("--------------------");
                            Console.WriteLine();
                        }
                        else
                        {
                            account.balance = 0;
                            context.tbAccounts.Add(account);
                            context.SaveChanges();
                            Console.WriteLine("ACCOUNT CREATED");
                            Console.WriteLine("--------------------");
                            Console.WriteLine();
                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            StartSystem();

        }

        #endregion

        #region Deposit
        static private void Deposit()
        {
            using (var context = new ApplicationDbContext())
            {

                Console.Write("ENTER IBAN : ");
                var iban = Console.ReadLine().ToUpper();
                Accounts account = GetAccountByIBAN(iban);

                if (account != null)
                {
                    Console.WriteLine($"NAME : {account.firstName} {account.lastName}");
                    Console.WriteLine($"Current Balance : {account.balance.ToString("0.##")}");
                    Console.WriteLine();
                    Console.Write("Deposit Amount : ");
                    var amount = Console.ReadLine();
                    var depositAmount = decimal.Parse(amount);
                    decimal feeRate = 0.1M;
                    var fee = (depositAmount * feeRate) / 100;
                    var postAmount = depositAmount - fee;
                    Console.WriteLine("-------------------");
                    Console.WriteLine();
                    Console.WriteLine($"DEPOSIT MONEY TO {account.firstName} {account.lastName} ");
                    Console.WriteLine($"FEE : {fee.ToString("0.##")}");
                    Console.WriteLine($"TOTAL AMOUNT : {postAmount.ToString("0.##")}");
                    Console.WriteLine("PLEASE CONFIRM TO DEPOSIT [Y/N] : ");
                    var cmf = Console.ReadLine().ToUpper();
                    if (cmf == "Y")
                    {
                        account.balance += postAmount;
                        context.Attach(account);
                        context.Entry(account).Property(p => p.balance).IsModified = true;
                        context.SaveChanges();

                        Console.WriteLine("MONEY DEPOSITED!");
                        Console.WriteLine($"CURRENT BALANCE : {account.balance}");
                        Console.WriteLine("-------------------");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("ACCOUNT NOT FOUND PLEASE TRY AGAIN!");
                    Deposit();
                }
            }

            StartSystem();
        }
        #endregion

        #region Transfer
        static private void Transfer()
        {
            using (var context = new ApplicationDbContext())
            {

                Console.Write("ENTER IBAN : ");
                var iban = Console.ReadLine().ToUpper();
                Accounts account = GetAccountByIBAN(iban);

                if (account != null)
                {
                    Console.Write("ENTER DESTINATION IBAN : ");
                    var desIban = Console.ReadLine().ToUpper();
                    Accounts desAccount = GetAccountByIBAN(desIban);

                    while (desAccount == null)
                    {
                        Console.WriteLine("ACCOUNT NOT FOUND PLEASE TRY AGAIN!");
                        Console.WriteLine("---------------------");
                        Console.Write("ENTER DESTINATION IBAN : ");
                        desIban = Console.ReadLine().ToUpper();
                        desAccount = GetAccountByIBAN(desIban);
                    }
                    Console.Write("ENTER TRANSFER AMOUNT : ");
                    var amount = Console.ReadLine();
                    var transferAmount = decimal.Parse(amount);
                    while(transferAmount < 0)
                    {
                        Console.WriteLine("INVALID AMOUNT PLEASE TRY AGAIN!");
                        Console.Write("ENTER TRANSFER AMOUNT : ");
                        amount = Console.ReadLine();
                        transferAmount = decimal.Parse(amount);
                    }
                    while (transferAmount > account.balance)
                    {
                        Console.WriteLine("INSUFFICIENT AMOUNT PLEASE TRY AGAIN!");
                        Console.Write("ENTER TRANSFER AMOUNT : ");
                        amount = Console.ReadLine();
                        transferAmount = decimal.Parse(amount);
                    }

                    Console.WriteLine("TRANSFER");
                    Console.WriteLine($"FROM {account.firstName} {account.lastName}");
                    Console.WriteLine($"TO {desAccount.firstName} {desAccount.lastName}");
                    Console.WriteLine($"AMOUNT : {transferAmount.ToString("0.##")}");
                    Console.Write("PLEASE CONFIRM TO TRANSFER [Y/N] : ");
                    var cmf = Console.ReadLine().ToUpper();
                    if (cmf == "Y")
                    {
                        account.balance -= transferAmount;
                        desAccount.balance += transferAmount;
                        context.Attach(account);
                        context.Entry(account).Property(p => p.balance).IsModified = true;
                        context.Attach(desAccount);
                        context.Entry(desAccount).Property(p => p.balance).IsModified = true;
                        context.SaveChanges();
                        Console.WriteLine("TRANSFER SUCCESSFUL!");
                        Console.WriteLine("---------------------");
                        Console.WriteLine();
                    }

                }
                else
                {
                    Console.WriteLine("ACCOUNT NOT FOUND PLEASE TRY AGAIN!");
                    Transfer();
                }
            }
            StartSystem();
        }
        #endregion

    }
}
