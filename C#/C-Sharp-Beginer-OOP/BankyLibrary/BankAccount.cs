using System;
using System.Text;
using System.Collections.Generic;
namespace MyBank_OOP_Project
{
    public class BankAccount
    {
        public string Number
        {
            get;
        }

        public string Owner
        {
            get;
            set;
        }

        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
            
        }
        private static int accountnumberseed = 123456789;

        private List<Transaction> allTransactions = new List<Transaction>();


        public BankAccount (string name,decimal initialBAlance)
        {
            this.Owner = name;
            MakeDeposit(initialBAlance, DateTime.Now, "Initial Balance");
            this.Number = accountnumberseed.ToString();
            accountnumberseed++;
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount<=0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithDraw (decimal amount, DateTime date, string note)
        {
            if (amount<=0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount),"Amount of withdraw must be positive");
            }
            if (Balance - amount<0)
            {
                throw new InvalidOperationException("not sufficent funds for this withdraw");
            }
            var withdwaral = new Transaction(-amount, date, note);
            allTransactions.Add(withdwaral);
        }



        //Transation History
        public string GetAccountHistory ()
        {
            var report = new StringBuilder();

            //HEADER OF TABLE
            report.AppendLine("Date\t\tAmount\t\tNote");
            foreach (var item in allTransactions)
            {
                //ROWS
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.AmountForHuman}\t\t{item.Notes}");
            }
            return report.ToString();
        }
    }
}
