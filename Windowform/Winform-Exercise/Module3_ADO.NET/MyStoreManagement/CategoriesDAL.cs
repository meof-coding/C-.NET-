using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace MyStoreManagement
{
    class Category
    {
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }
    }
    class CategoriesDAL
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
       
        public List<Category> GetCategories()
        {
            
            List<Category> categories = new List<Category>();
            connection = new SqlConnection(GetConnectionString());
            command = new SqlCommand("select * from Categories", connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if(reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        categories.Add(new Category
                        {
                            CategoryID = reader.GetInt32("CategoryID"),
                            CategoryName = reader.GetString("CategoryName")
                        });
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return categories;
        }

        public int InsertCategory(Category category)
        {
            int result = 0;
            //Mo ket noi
            connection = new SqlConnection(GetConnectionString());
            command = new SqlCommand("insert into Categories(CategoryName) values(@catName)", connection);
            command.Parameters.AddWithValue("@catName", category.CategoryName);
            try
            {
                connection.Open();
                result=command.ExecuteNonQuery();
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

        public int UpdateCategory(Category category)
        {
            int result = 0;
            connection = new SqlConnection(GetConnectionString());
            command = new SqlCommand("update Categories set CategoryName = @catName where CategoryID= @catID", connection);
            command.Parameters.AddWithValue("@catName", category.CategoryName);
            command.Parameters.AddWithValue("@catID", category.CategoryID);
            try
            {
                connection.Open();
                result=command.ExecuteNonQuery();
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

        public int DeleteCategory(Category category)
        {
            int result = 0;
            connection = new SqlConnection(GetConnectionString());
            command = new SqlCommand("DELETE FROM Categories WHERE CategoryID = @catID", connection);
            command.Parameters.AddWithValue("@catID", category.CategoryID);
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
