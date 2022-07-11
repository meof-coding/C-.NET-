using System;

namespace EX3_2
{
    class Person
    {
        int age;

        public Person(int age)
        {
            this.age = age;
        }

        public Person()
        {
        }

        public void Greet()
        {
            Console.WriteLine("Hello!");
        }

        public int Age { get { return age; } set { age = value; } }
    }

    class Student:Person
    {
        public Student(int age) : base(age)
        {
        }

        public void Study()
        {
            Console.WriteLine("I'm studying");
        }

        public void ShowAge()
        {
            Console.WriteLine($"My age is: {Age} years old");
        }
    }

    class Professor : Person
    {
        public Professor(int age) : base(age)
        {
        }

        public void Explain() {
            Console.WriteLine("I'm explaining");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            p.Greet();
            Student s = new Student(21);
            s.Greet();
            s.ShowAge();
            s.Study();
            Professor t = new Professor(80);
            t.Greet();
            t.Explain();
        }
    }
}
