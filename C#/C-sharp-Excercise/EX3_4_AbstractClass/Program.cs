using System;

namespace EX3_4_AbstractClass
{
    abstract class Animal
    {
        public string name;

        protected Animal(string aname)
        {
            name = aname;
        }

        public string Name { get { return name; } set { name = value; } }

        public abstract void Eat();
    }
    class Dog : Animal
    {
        public Dog(string aname) : base(aname)
        {
        }

        public override void Eat()
        {
            Console.WriteLine("Dog is Eating");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog(Console.ReadLine());
            Console.WriteLine(dog.name);
            dog.Eat();
        }
    }
}
