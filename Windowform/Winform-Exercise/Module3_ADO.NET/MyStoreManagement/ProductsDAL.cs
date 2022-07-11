using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace MyStoreManagement
{

    class Products
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        public int CategoryID { get; set; }

        public int UnitsInStock { get; set; }

       
    }
    class ProductsDAL
    {
        //Khai bao doi tuong ket noi 
        SqlConnection connection;

        //Khai bao doi tuong thuc thi cac truy van
        SqlCommand command;

        //Phuong thuc lay chuoi ket noi tu appsettings.json
        string GetConnectionString()
        {
            //Khai bao va lay chuoi ket noi tu appsettings.json
            IConfiguration config = new ConfigurationBuilder()
                                    .SetBasePath(Directory.GetCurrentDirectory())
                                    .AddJsonFile("appsettings.json", true, true).Build();

            return config["ConnectionStrings:MyStoreDB"];
        }

        //Get Data from DB
        public List<Products> GetProducts()
        {

            List<Products> products = new List<Products>();
            connection = new SqlConnection(GetConnectionString());
            command = new SqlCommand("select * from Products", connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        products.Add(new Products
                        {
                            ProductID = reader.GetInt32("ProductID"),
                            ProductName = reader.GetString("ProductName"),
                            UnitPrice = reader.GetDecimal("UnitPrice"),
                            CategoryID = reader.GetInt32("CategoryID"),
                            UnitsInStock = reader.GetInt32("UnitsInStock"),
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return products;
        }

        //Sort All by Name
        public List<Products> SortProduct()
        {

            List<Products> products = new List<Products>();
            connection = new SqlConnection(GetConnectionString());
            command = new SqlCommand("SELECT * FROM Products ORDER BY ProductName", connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        products.Add(new Products
                        {
                            ProductID = reader.GetInt32("ProductID"),
                            ProductName = reader.GetString("ProductName"),
                            UnitPrice = reader.GetDecimal("UnitPrice"),
                            CategoryID = reader.GetInt32("CategoryID"),
                            UnitsInStock = reader.GetInt32("UnitsInStock"),
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return products;
        }


        //Sort By Specific Column
        public List<Products> SortColumn(string sort_query)
        {

            List<Products> products = new List<Products>();
            connection = new SqlConnection(GetConnectionString());
            command = new SqlCommand(sort_query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        products.Add(new Products
                        {
                            ProductID = reader.GetInt32("ProductID"),
                            ProductName = reader.GetString("ProductName"),
                            UnitPrice = reader.GetDecimal("UnitPrice"),
                            CategoryID = reader.GetInt32("CategoryID"),
                            UnitsInStock = reader.GetInt32("UnitsInStock"),
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return products;
        }


        //Insert Product
        public int InsertProduct(Products products)
        {
            int result = 0;
            //Mo ket noi
            connection = new SqlConnection(GetConnectionString());
            command = new SqlCommand("insert into Products(ProductName,UnitPrice,CategoryID,UnitsInStock) values(@proName,@price,@catID,@uStock)", connection);
            command.Parameters.AddWithValue("@proName", products.ProductName);
            command.Parameters.AddWithValue("@price", products.UnitPrice);
            command.Parameters.AddWithValue("@catID",products.CategoryID);
            command.Parameters.AddWithValue("@uStock", products.UnitsInStock);
             try
            {
                connection.Open();
                result = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return result;
        }


        //Update Product
        public int UpdateProduct(Products products)
        {
            int result = 0;
            connection = new SqlConnection(GetConnectionString());
            command = new SqlCommand("update Products set ProductName = @pName,UnitPrice = @uPrice, CategoryID=@catID, UnitsInStock =@uStock where ProductID= @pID", connection);
            command.Parameters.AddWithValue("@pName", products.ProductName);
            command.Parameters.AddWithValue("@uPrice", products.UnitPrice);
            command.Parameters.AddWithValue("@catID", products.CategoryID);
            command.Parameters.AddWithValue("@uStock", products.UnitsInStock);
            command.Parameters.AddWithValue("@pID", products.ProductID);
            try
            {
                connection.Open();
                result = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return result;
        }


        //Delete Product
        public int DeleteProduct(Products product)
        {
            int result = 0;
            connection = new SqlConnection(GetConnectionString());
            command = new SqlCommand("DELETE FROM Products WHERE ProductID = @pID", connection);
            command.Parameters.AddWithValue("@pID", product.ProductID);
            try
            {
                connection.Open();
                result = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        //Delete Multiple Product
        public int DeleteMultipleProduct(string index)
        {
            string query = $"delete from Products where ProductID in ({index})";
            int result = 0;
            connection = new SqlConnection(GetConnectionString());
            command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                result = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
    }
}
