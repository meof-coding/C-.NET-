using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    //string conenctionString = ConfigurationManager.ConnectionStrings["desktop-bbmab7u\\sqlexpress.Northwind.dbo"].ConnectionString.ToString();
    public List<Product> getProducts(int CategoryId)
    {
        SqlConnection con = new SqlConnection(@"Data Source=(local);Initial Catalog=Northwind;Persist Security Info=True;User ID=sa;Password=19112001");
        con.Open();
        SqlCommand com = new SqlCommand("select * from Products where CategoryID = @CategoryID", con);
        com.Parameters.AddWithValue("@CategoryID", CategoryId);
        var ProductList = new List<Product>();
        //sql command to get product by category id
        SqlDataReader reader = com.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                ProductList.Add(new Product
                {
                    ProductID = reader.GetInt32(0),
                    ProductName = reader.GetString(1),
                    SupplierID = reader.GetInt32(2),
                    CategoryID = reader.GetInt32(3),
                    QuantityPerUnit = reader.GetString(4),
                    UnitPrice = reader.GetDecimal(5),
                    UnitsInStock = reader.GetInt16(6),
                    UnitsOnOrder = reader.GetInt16(7),
                    ReorderLevel = reader.GetInt16(8),
                    Discontinued = reader.GetBoolean(9)
                });
            }
        }
        con.Close();
        return ProductList;
    }
    public double Add(double n1, double n2)
    {
        double result = n1 + n2;
        Console.WriteLine("Received Add({0},{1})", n1, n2);
        // Code added to write output to the console window.
        Console.WriteLine("Return: {0}", result);
        return result;
    }
}
