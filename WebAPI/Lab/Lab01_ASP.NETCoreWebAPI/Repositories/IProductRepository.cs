using Bussiness_Object;
using Bussiness_Object.DataAccess;

namespace Repositories
{
    public interface IProductRepository
    {
        ///Save product
        void SaveProduct(Product p);
        ///Get product by ID
        Product GetProductById(int id);
        ///Delete Product
        void DeleteProduct(Product p);
        ///Update Product
        void UpdateProduct(Product p);
        ///Get Categories
        List<Category> GetCategories();
        ///Get list Products
        List<Product> GetProducts();
    }
}