using Bussiness_Object;
using Bussiness_Object.DataAccess;

namespace DataAccess
{
    public class CategoryDAO
    {
        public static List<Category> GetCategories()
        {
            var listCategory = new List<Category>();
            try
            {
                using (var context = new NorthwindContext())
                {
                    listCategory = context.Categories.ToList();
                }
            }
            catch (Exception)
            {
                //log error
                Console.WriteLine("No item in Category table");
            }
            return listCategory;
        }
    }
}