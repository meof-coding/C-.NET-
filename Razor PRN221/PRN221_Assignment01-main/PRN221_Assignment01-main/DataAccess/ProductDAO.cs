using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductDAO
    {
        FStoreDBAssignmentContext fStoreContext = new FStoreDBAssignmentContext();

        private static ProductDAO instance = null;
        private static readonly object instanceLock = new object();



        private ProductDAO() { }
        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                    return instance;
                }
            }
        }


        public List<Product> GetProducts => fStoreContext.Products.ToList();

        public List<Product> GetProductByName(string name)
        {
            List<Product> products = (from a in fStoreContext.Products.ToList() where a.ProductName.ToLower().Contains(name.ToLower()) select a).ToList<Product>();
            return products;
        }

        public List<Product> GetProductByPrice(decimal minPrice, decimal maxPrice)
        {
            List<Product> products = (from a in fStoreContext.Products.ToList() where (a.UnitPrice > minPrice && a.UnitPrice < maxPrice) select a).ToList<Product>();
            return products;
        }

        public List<Product> GetProductByUnitInStock(int quantity)
        {
            List<Product> products = (from a in fStoreContext.Products.ToList() where a.UnitslnStock <= quantity select a).ToList<Product>();
            return products;
        }

        public Product GetProductById(int productId)
        {
            Product pro = fStoreContext.Products.SingleOrDefault<Product>(p => p.ProductId == productId);
            return pro;
        }

        public void Add(Product product)
        {
            if (GetProductById(product.ProductId) == null)
            {
                fStoreContext.Products.Add(product);
                fStoreContext.SaveChanges();
            }
            else
            {
                throw new Exception("Try another id");
            }
        }

        public void Delete(int productId)
        {
            if (GetProductById(productId) != null)
            {
                fStoreContext.Remove(fStoreContext.Products.FirstOrDefault<Product>(p => p.ProductId == productId));
                fStoreContext.SaveChanges();
            }
            else
            {
                throw new Exception("Invalid ID");
            }
        }

        public void Update(Product product)
        {
            Product pro = GetProductById(product.ProductId);
            if (pro != null)
            {
                pro.CategoryId = product.CategoryId;
                pro.ProductName = product.ProductName;
                pro.UnitslnStock = product.UnitslnStock;
                pro.UnitPrice = product.UnitPrice;
                pro.Weight = product.Weight;
                fStoreContext.SaveChanges();
            }
            else
            {
                throw new Exception("Product does not exitst");
            }
        }


    }
}
