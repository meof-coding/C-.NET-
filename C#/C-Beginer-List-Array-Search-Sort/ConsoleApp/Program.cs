using System;
using System.Collections.Generic;
//import Library
namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args) //String array of args 
        {
            /*
              // List, Array, Collection
            var names = new List<string> {"Tea","Jun","Bun","Chuoi" };
            //using var when you not know the type of variable is going to be
            names.Add("meof");
            names.Remove("Chuoi");
            Console.WriteLine($"The List of name has {names.Count} number of names");
            // Sort,Search, and Index Lists

            //Searh
            /*
            var index = names.IndexOf("Bun"); //ask for specific index
            if (index == -1)
            {
                Console.WriteLine($"The name not found");
            }
            else
            {
                Console.WriteLine($"The name {names[index]} is at index: {index}");
            }
            */
            //Sort
            /*
             names.Sort();
            //Sort() is using the default conparer

            foreach (var name in names)
            {
                Console.WriteLine($"Hello {name}!");
            }

            */

            //LIST OF OTHER TYPE
            var FibonacciNumber = new List<int> { 1, 1 };
            while (FibonacciNumber.Count<20)
            {
                var previous = FibonacciNumber[FibonacciNumber.Count - 1];
                var previous2 = FibonacciNumber[FibonacciNumber.Count - 2];
                FibonacciNumber.Add(previous + previous2);
            }
            foreach (var item in FibonacciNumber)
            {
                Console.WriteLine($"{item} ");
            }

        }
    }
}
