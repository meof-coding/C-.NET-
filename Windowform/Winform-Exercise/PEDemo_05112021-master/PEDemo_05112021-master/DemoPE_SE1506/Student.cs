using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPE_SE1506
{
    class Student
    {
        public Student(string c)
        {
            code = c;
        }

        private string code { get; set; }
        private string name { get; set; }

        public void InputInfo()
        {
            Console.WriteLine("Input name for student please. The student name should be less than 15 characters.");
            string name = Console.ReadLine();
            if (name.Length <= 15) this.name = name;
            else throw new IncorrectNameFormatException();
        }

        public override string ToString()
        {
            return $"Student’s Information: Code: {code} – Name: {name} \n\n";
        }
    }
}
