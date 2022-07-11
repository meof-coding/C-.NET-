using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Q1
{
    class Product
    {
        private string id;
        private string name;
        private float price;

        public Product(string id, string name, float price)
        {
            this.ID = id;
            this.Name = name;
            this.Price = price;
        }
        public Product()
        {

        }
        public string ID { get { return id; } set { id = value; } }

        public string Name { get { return name; } set { name = value; } }

        public float Price { get { return price; } set { price = value; } }



        public override string ToString()
        {
            return $"{ID} - {Name} - {Price}";
        }
    }
    class Program
    {
        public static IList<Product> Add(IList<Product> list)
        {
            Console.Write("Enter ID:");
            string id = Console.ReadLine();
            Console.Write("Enter Name:");
            string name = Console.ReadLine();
            Console.Write("Enter Price:");
            int price = int.Parse(Console.ReadLine());
            Product p = new Product(id, name, price);
            list.Add(p);
            return list;
        }

        public static void Display(IList<Product> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        public static void Search(IList<Product> list)
        {
            Console.Write("Enter the product name to search:");
            string name = Console.ReadLine();
            List<Product> arr_list = new List<Product>();
            foreach (var item in list)
            {
                if (item.Name.StartsWith(name.ToLower()) || item.Name.StartsWith(name.ToUpper()))
                {
                    arr_list.Add(item);
                }

            }

            foreach (var item in arr_list)
            {
                Console.WriteLine(item);
                if (arr_list.Count == 0)
                {
                    Console.WriteLine("Product not exit!");
                }
            }

        }

        public static void Sort(IList<Product> list)
        {
            Console.WriteLine("Product list after sorted:");
            List<Product> sortedProduct = list.OrderBy(product => product.Name).ThenByDescending(product => product.Price).ToList();
            foreach (Product product in sortedProduct)
                Console.WriteLine(product);
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            IList<Product> list = new List<Product>() {
                new Product(){ ID = "P002", Name="IPhone", Price=1200},
                new Product(){ ID = "P003", Name="Galaxy Note 10", Price=1000f},
                new Product(){ ID = "P001", Name="IPhone", Price=1500.5f}
            };
            while (true)
            {
                Console.Clear();
                Console.WriteLine("------- PRODUCT MANAGEMENT -------");
                Console.WriteLine("1. Add                                ");
                Console.WriteLine("2. Display                            ");
                Console.WriteLine("3. Sort                               ");
                Console.WriteLine("4. Search                             ");
                Console.WriteLine("5. Exit                               ");
                Console.Write("Enter a option: ");
                int option;
                int.TryParse(Console.ReadLine(), out option);

                switch (option)
                {
                    case 1:
                        Add(list); break;
                    case 2:
                        Console.WriteLine("Product list:");
                        Display(list); break;
                    case 3:
                        Sort(list); break;
                    case 4:
                        Search(list); break;
                    case 5:
                        System.Environment.Exit(0); break;
                    default:
                        Console.WriteLine("Try again!"); break;
                }
            }
        }
    }
}
