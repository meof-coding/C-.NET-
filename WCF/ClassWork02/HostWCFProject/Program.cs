using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HostWCFProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.ServiceClient obj = new ServiceReference1.ServiceClient();
            ServiceReference1.Product[] productArr = obj.getProducts(1);
            int len = productArr.Length;
            foreach (ServiceReference1.Product product in productArr)
            {
                Console.WriteLine(product.ProductID);
                Console.WriteLine(product.ProductName);
                Console.WriteLine(product.SupplierID);
                Console.WriteLine(product.CategoryID);
                Console.WriteLine(product.QuantityPerUnit);
                Console.WriteLine(product.UnitPrice);
                Console.WriteLine(product.UnitsInStock);
                Console.WriteLine(product.UnitsOnOrder);
                Console.WriteLine(product.ReorderLevel);
                Console.WriteLine(product.Discontinued);
            }
            Console.WriteLine(obj.Add(1, 2));
            Console.ReadKey();

        }
    }
}
