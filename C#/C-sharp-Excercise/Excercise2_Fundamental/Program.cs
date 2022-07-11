using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Excercise2_Fundamental
{
    class Program
    {
        //EX11
        class Car
        {
            string Model;
            int AnyoFabricacion;
            public Car(string m, int y)
            {
                this.Model = m;
                this.AnyoFabricacion = y;
            }
            public string model { get { return Model; } }
            public int anyo { get { return AnyoFabricacion; } }
        }

        //EX15
        static void Double(ref int a)
        {
            Console.WriteLine(a * 2);
        }

        static void Main(string[] args)
        {
            //EX1
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            for (int i = a; i <= b; i++)
            {
                Console.Write($"{Math.Pow(i, 2) - 2 * i + 1} ");
            }

            //EX2
            int i = 1;
            int limit = 0;
            while (limit < 500 - 15)
            {
                limit = i * 3 * 5;
                i++;
                Console.Write(limit + " ");
            }

            //EX3
            int i = 0;
            List<string> a = new List<string>();
            while (i < 3)
            {
                string user = Console.ReadLine();
                string pw = Console.ReadLine();
                bool check_u = int.TryParse(user, out int number);
                bool check_p = int.TryParse(pw, out int mypass);
                if (check_p && check_u)
                {
                    if (number == 12 && mypass == 1234)
                    {
                        a.Add("true");
                    }
                    else
                    {
                        a.Add("false");
                    }
                }
                else
                {
                    a.Add("false");
                };
                i++;
            }
            foreach (string login in a)
            {
                if (login.Equals("true"))
                {
                    Console.WriteLine("Login successful ");
                }
                else
                {
                    Console.WriteLine("Login failed ");
                }
            }

            //EX4
            string num = Console.ReadLine();
            List<int> list = new List<int>();
            while (!num.Equals(""))
            {
                list.Add(int.Parse(num));
                num = Console.ReadLine();
            }
            for (int i = 0; i < list.Count; i += 2)
            {
                try
                {
                    int a = list[i + 1];
                    if (a == 0)
                    {
                        Console.WriteLine("You can not divide by 0");
                    }
                    else
                    {
                        Console.WriteLine($"The division is {list[i] / a}");
                        Console.WriteLine($"The rest is {list[i] % a}");
                    };
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Goodbye!");
                }

                //EX5
                int num1 = int.Parse(Console.ReadLine());
                int num2 = int.Parse(Console.ReadLine());
                //Using for statement
                for (int i = num1; i <= num2; i++)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
                //Using while statement
                int count = num1;
                while (count <= num2)
                {
                    Console.Write(count + " ");
                    count++;
                }
                Console.WriteLine();
                //Using do while statement
                do
                {
                    Console.Write(num1 + " ");
                    num1++;
                } while (num1 <= num2);

                //EX6
                int n = 5;
                Console.WriteLine($"Input {n} number of integer: ");
                List<int> list = new List<int>();
                while (n > 0)
                {
                    int i = int.Parse(Console.ReadLine());
                    list.Add(i);
                    n--;
                }
                int sum = 0;
                foreach (int ele in list)
                {
                    sum += ele;
                }
                Console.WriteLine($"Suma: {sum}");
                Console.WriteLine($"Media: {list[list.Count / 2]}");
                list.Sort((a, b) => (a.ToString()[0].CompareTo(b.ToString()[0])));
                Console.WriteLine($"Max: {list[list.Count - 1]}");
                Console.WriteLine($"Min: {list[0]}");

                //EX7
                bool check(int num, string name)
                {
                    var result = num > 0 ? true : false;
                    Console.WriteLine(result ? $"{name} is positive" : $"{name} is negative");
                    return result;
                }
                int A = int.Parse(Console.ReadLine());
                int B = int.Parse(Console.ReadLine());
                bool a = check(A, nameof(A));
                bool b = check(B, nameof(B));
                Console.WriteLine(a && b ? "Both are positive" : "Both are not positive");

                //EX8
                int x = int.Parse(Console.ReadLine());
                List<int> a = new List<int>();
                for (int i = 0; i < x; i++)
                {
                    a.Add(int.Parse(Console.ReadLine()));
                }
                int y = int.Parse(Console.ReadLine());
                string end = Console.ReadLine();
                Console.Write($"The number {y}");
                Console.Write(a.Contains(y)? " exist":" not exist");

                //EX9
                string num = Console.ReadLine();
                List<int> list = new List<int>();
                int sumpos = 0;
                int sumnega = 0;
                int pos = 0;
                int nega = 0;
                while (!num.Equals(""))
                {
                    list.Add(int.Parse(num));
                    num = Console.ReadLine();
                }
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] > 0)
                    {
                        sumpos += list[i];
                        pos++;
                    }
                    else
                    {
                        sumnega += list[i];
                        nega++;
                    };
                }
                Console.WriteLine($"Average numbers negatives is {sumnega / nega}");
                Console.WriteLine($"Average numbers positive is {sumpos / pos}");

                //EX10
                List<List<int>> list = new List<List<int>>();
                for (int i = 0; i < 2; i++)
                {
                    List<int> group = new List<int>();
                    for (int j = 0; j < 10; j++)
                    {
                        group.Add(int.Parse(Console.ReadLine()));

                    }
                    list.Add(group);
                }
                for (int num = 1; num <= list.Count; num++)
                {
                    int sum = 0;
                    int count = 0;
                    Console.Write($"Average for group {num} is ");
                    foreach (var ele in list[num - 1])
                    {
                        sum += ele;
                        count++;
                        if (count == 5)
                        {
                            Console.Write(sum / (list[num - 1].Count / 2) + ", ");
                            count = 0;
                            continue;
                        }

                    }
                    Console.WriteLine();
                }

                //EX11
                List<Car> cars = new List<Car>();
                string line = Console.ReadLine();
                while (!line.Equals(""))
                {
                    int year = int.Parse(Console.ReadLine());
                    cars.Add(new Car(line, year));
                    line = Console.ReadLine();
                }
                cars.Sort((s1, s2) => s1.anyo.CompareTo(s2.anyo));
                //var sorted = cars.OrderBy(h => h.anyo);
                foreach (var item in cars)
                {
                    Console.WriteLine($"Model: {item.model}, Year of production: {item.anyo}");
                }

                //EX12   
                string line = Console.ReadLine();
                List<string> list = new List<string>();
                while (!line.Equals(""))
                {
                    list.Add(line);
                    line = Console.ReadLine();

                }
                for (int i = 0; i < list.Count; i += 2)
                {
                    try
                    {
                        int a = int.Parse(list[i + 1]);
                        Console.WriteLine(list[i].Substring(0, a));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine();
                    }
                }

                //EX13
                string pattern = @"[a-zA-Z]+";
                //string pattern = @"^[a-zA-Z]+$";
                Regex rgx = new Regex(pattern);
                string line = Console.ReadLine();
                List<string> list = new List<string>();
                while (!line.Equals(""))
                {
                    list.Add(line);
                    line = Console.ReadLine();
                }
                foreach (var item in list)
                {
                    if (rgx.IsMatch(item))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }

                //EX14
                string pattern = @"^\d+$";
                Regex rgx = new Regex(pattern);
                string line = Console.ReadLine();
                List<string> list = new List<string>();
                while (!line.Equals(""))
                {
                    list.Add(line);
                    line = Console.ReadLine();
                }
                foreach (var item in list)
                {
                    if (rgx.IsMatch(item))
                    {
                        Console.WriteLine("True");
                    }
                    else
                    {
                        Console.WriteLine("False");
                    }
                }

                //EX15
                int num = int.Parse(Console.ReadLine());
            Double(ref num);
        }
    }
}


