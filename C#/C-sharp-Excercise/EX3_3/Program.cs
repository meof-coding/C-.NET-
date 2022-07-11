using System;

namespace EX3_3
{
    interface IVehiculo
    {
        void Drive();
        bool Refuel(int amount_of_gasoline);
    }

    class Car : IVehiculo
    {
        int amount;

        public Car(int amount)
        {
            this.amount = amount;
        }

        public int Amount { get {return amount; }set { amount = value; } }

        void IVehiculo.Drive()
        {
            if (Amount>0)
            {
                Console.WriteLine("Driving");
            }
            else
            {
                Console.WriteLine("Out of gas!");
            }
        }

        bool IVehiculo.Refuel(int amount_of_gasoline)
        {
            while (Amount<amount_of_gasoline)
            {
                Amount++;
            }
            return true;
        }
    }
    class Program
    {
        static void Main(string[] args)
         {
            Car car = new Car(0);
            Console.WriteLine("How many gas do you want to refuel?");
            int gas = int.Parse(Console.ReadLine());
            IVehiculo vehiculo = car;
            vehiculo.Refuel(gas);
            vehiculo.Drive();
        }
    }
}
