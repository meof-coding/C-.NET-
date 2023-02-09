using Bussiness_Object;
using Bussiness_Object.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductDAO
    {
        public static List<Product> GetProducts()
        {
            var listProducts = new List<Product>();
            try
            {
                using (var context = new NorthwindContext())
                {
                    listProducts = context.Products.Include(p => p.Category).Include(p => p.Supplier).ToList();
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return listProducts;
        }

        public static Product FindProductById(int proId)
        {
            Product p = new Product();
            try
            {
                using (var context = new NorthwindContext())
                {
                    p = context.Products.Include(p => p.Category)
                .Include(p => p.Supplier).SingleOrDefault(x => x.ProductId == proId);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return p;
        }

        public static void SaveProduct(Product p)
        {
            try
            {
                using (var context = new NorthwindContext())
                {
                    context.Products.Add(p);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
        }

        public static void UpdateProduct(Product p)
        {
            try
            {
                using (var context = new NorthwindContext())
                {
                    context.Entry<Product>(p).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
        }

        public static void DeleteProduct(Product p)
        {
            try
            {
                using (var context = new NorthwindContext())
                {
                    var p1 = context.Products.SingleOrDefault(c => c.ProductId == p.ProductId);
                    context.Products.Remove(p1);
                    var o1 = context.OrderDetails.Where(c => c.ProductId == p.ProductId);
                    context.OrderDetails.RemoveRange(o1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
        }

    }
}
