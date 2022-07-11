using System;
using System.Collections.Generic;

namespace PE_Exercise_Q2
{
    class MyCollection<T>
    {
        List<T> list;

        public MyCollection()
        {
            list = new List<T>();
        }

        public void Add(T obj)
        {
            list.Add(obj);
        }

        public void Add(T obj, int k)
        {
            list.Insert(k, obj);
        }

        public void DisplayItems()
        {
            Console.WriteLine("Items in my collection:");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyCollection<int> IntCollection = new MyCollection<int>();
            IntCollection.Add(1);
            IntCollection.Add(2);
            IntCollection.Add(3);
            IntCollection.Add(4, 1);
            Console.WriteLine("Display integer list:");
            IntCollection.DisplayItems();

            MyCollection<string> StringCollection = new MyCollection<string>();
            StringCollection.Add("aa");
            StringCollection.Add("bb");
            StringCollection.Add("cc");
            StringCollection.Add("dd", 1);
            Console.WriteLine("Display string list:");
            StringCollection.DisplayItems();
            Console.ReadLine();

        }
    }
}
