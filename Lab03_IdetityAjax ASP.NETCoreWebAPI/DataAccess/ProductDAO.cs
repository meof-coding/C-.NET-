using BusinessObjects.DataAccess;
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
                using (var db = new NorthwindContext())
                {
                    listProducts = db.Products.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listProducts;
        }

        //Find Product By Id
        public static Product FindProductById(int id)
        {
            var product = new Product();
            try
            {
                using (var db = new NorthwindContext())
                {
                    product = db.Products.SingleOrDefault(x => x.ProductId == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }

        //Save Product
        public static void SaveProduct(Product product)
        {
            try
            {
                using (var db = new NorthwindContext())
                {
                    db.Products.Add(product);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Update Product
        public static void UpdateProduct(Product product)
        {
            try
            {
                using (var db = new NorthwindContext())
                {
                    db.Entry<Product>(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Delete Product
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
