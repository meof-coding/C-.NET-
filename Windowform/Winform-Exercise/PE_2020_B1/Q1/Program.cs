using System;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        class Student
        {
            private string code;
            private string name;
            private DateTime dob;

            public string Code
            {
                get
                {
                    return code;
                }
                set
                {
                    if (!Regex.IsMatch(value, @"^[a-zA-Z]{2}\d{6}$"))
                    {
                        throw new FormatException("The student's code is not in the right format");
                    }
                    else
                    {
                        code=value;
                    }
                }
            }
            public string  Name { get {return name; } set {name = value; } }
            public DateTime DOB { get {return dob; } set {dob = value; } }

            public Student(){
                code = "HE150186";
                name = "Nguyen Thanh Tra";
                dob = Convert.ToDateTime("11/19/2001");
                    }

            public override string ToString()
            {
                return $"Student's Info:\nCode: {Code}, Name: {Name}, DOB:{DOB}";
            }
        }
        static void Main(string[] args)
        {
            Student s = new Student();
            Console.WriteLine(s.ToString());
            while (true)
            {
                Console.WriteLine("\nInput new info for student:");
                try
                {
                    Console.WriteLine("New Code:");
                    s.Code = Console.ReadLine();
                    Console.WriteLine("New Name:");
                    s.Name = Console.ReadLine();
                    Console.WriteLine("New DOB:");
                    s.DOB = Convert.ToDateTime(Console.ReadLine());
                    break;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Input again, pls");
                }
            }
            Console.WriteLine(s.ToString());
            Console.ReadLine();
        }
    }
}
