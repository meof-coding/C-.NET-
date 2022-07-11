using System;

namespace PE_Exercise_Q1
{
    class Student
    {
        private int id;
        private string name;
        private DateTime dob;

        public Student(int id, string name, DateTime dob)
        {
            this.id = id;
            this.name = name;
            this.dob = dob;
        }
        public int ID { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public DateTime DOB { get { return dob; } set { dob = value; } }

        public int GetAge()
        {
            return DateTime.Now.Year - DOB.Year;
        }

        public override string ToString()
        {
            return $"Student’s Information: ID: {ID} – Name: {Name} – Age: {GetAge()}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student st = new Student(1, "Trung", new DateTime(1990, 11, 10));
            Console.WriteLine("Age of student: " + st.GetAge().ToString());
            Console.WriteLine(st.ToString());
            Console.ReadLine();

        }
    }
}
