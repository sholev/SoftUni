namespace BankOfKurtovoKonare
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using Classes;
    using static Classes.Enumerations;
    using Interfaces;

    public class BankOfKurtovoKonare
    {
        private static void Main(string[] args)
        {
            Random rng = new Random();
            string[] namesPeople = File.ReadAllLines("../../namesPeople.txt");
            string[] namesCorporate = File.ReadAllLines("../../namesCompany.txt");

            List<IAccount> accounts = new List<IAccount>();

            for (int i = 0; i < 15; i++)
            {
                CustomerType type = (CustomerType)rng.Next(0, 2);
                decimal interestRate = (decimal)rng.NextDouble() / 4;

                decimal balance;
                Customer customer;
                if (type == CustomerType.Individual)
                {
                    customer = new Customer(namesPeople[rng.Next(0, namesPeople.Length)], type);
                    balance = (decimal)(rng.Next() + rng.NextDouble()) / 100000;
                }
                else
                {
                    customer = new Customer(namesCorporate[rng.Next(0, namesPeople.Length)], type);
                    balance = (decimal)(rng.Next() + rng.NextDouble()) / 1000;
                }
                
                switch (rng.Next(0, 3))
                {
                    case 0:
                        accounts.Add(new AccountDeposit(customer, balance, interestRate));
                        break;

                    case 1:
                        accounts.Add(new AccountLoan(customer, balance, interestRate));
                        break;

                    case 2:
                        accounts.Add(new AccountMortgage(customer, balance, interestRate));
                        break;
                }                
            }

            Console.SetWindowSize(100, 30);
            foreach (var account in accounts)
            {
                int months = rng.Next(0, 50);
                Console.WriteLine(
                    $"{account}\r\n{new String(' ', 40)}Calculated Interest: {account.CalculateInterest(months):F2} for {months} months.");
                Console.WriteLine(new string('-', 100));
            }
        }
    }
}
