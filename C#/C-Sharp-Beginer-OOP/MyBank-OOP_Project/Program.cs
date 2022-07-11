using System;
using Humanizer;

namespace MyBank_OOP_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ex of Humanizer
            Console.WriteLine("car".Pluralize());
            Console.WriteLine(2345.ToWords());

            var acount = new BankAccount("Kendra",23000);
            Console.WriteLine($"Account {acount.Number} was created for {acount.Owner} with {acount.Balance} ");

            acount.MakeWithDraw(120, DateTime.Now, "Tokkboki");
            Console.WriteLine(acount.Balance);

            Console.WriteLine(acount.GetAccountHistory());

           
        }
    }
}
