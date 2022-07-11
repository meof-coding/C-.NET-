using System;
using System.Collections.Generic;

namespace Exercise3_OOP_in_Csharp
{
    //EX1
    class Person
    {
        private string name;

        public Person(string name)
        {
            this.name = name;
        }

        public string Name {
            get
            {
                return name;
            }
            }


        public override string ToString()
        {
            return $"Hello!My name is {Name}";
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            //EX1
            int i = 3;
            List<Person> person = new List<Person>();
            while (i>0)
            {
                person.Add(new Person(Console.ReadLine()));
                i--;
            }

            foreach (var item in person)
            {
                Console.WriteLine(item.ToString());
            }

        }
    }
}
