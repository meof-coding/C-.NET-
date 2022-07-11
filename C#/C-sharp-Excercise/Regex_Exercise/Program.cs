using System;
using System.Text.RegularExpressions;

namespace Regex_Exercise
{
     public class Student
    {
        private string roll;
        private string name;
        private string email;
        private int phone;


        public Student(string roll, string name, string email, int phone)
        {
            this.Roll = roll;
            this.Name = name;
            this.Email = email;
            this.Phone = phone;
        }

        public Student()
        {
        }

        public string Roll
        {
            get
            {
                return roll;
            }
            set
            {
                roll = value;
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public int Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
            }
        }

        public void InputInfo(string a,string b,string c,int d)
        {
            if (Regex.IsMatch(a, @"^SE\d{6}|HE\d{6}$") && Regex.IsMatch(d.ToString(), @"^\d{10}$") &&Regex.IsMatch(b, @"^[a-zA-Z]+$")&&Regex.IsMatch(c, @"^\w+@\w+[.]?.*")) {
                Student s = new Student(a, b, c, d);
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine(s.DisplayInfo());
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid format,enter again!!",Console.ForegroundColor);
                InputInfo(Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), int.Parse(Console.ReadLine()));
            }
     }

        public string DisplayInfo()
        {
            return $"Roll number: {Roll},Name student: {Name}, Email: {Email}, Phone: {Phone}";
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Enter information: ",Console.ForegroundColor);
            Student s = new Student();
            s.InputInfo(Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), int.Parse(Console.ReadLine()));

        }
    }
}
