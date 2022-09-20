using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingDBWithADO_Net
{
    public record Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
    class ManageCategories
    {
        SqlConnection connection;
        SqlCommand command;
        string connectionString = "server=(local);database=MyStoreDB; uid=sa;pwd=12345678";

        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            connection = new SqlConnection(connectionString);
            string sql = "SELECT * FROM Categories";
            command = new SqlCommand(sql, connection);
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
                            CategoryId = reader.GetInt32("CategoryId"),
                            CategoryName = reader.GetString("CategoryName")
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
            return categories;
        }

        public void InsertCategory(Category category)
        {
            connection = new SqlConnection(connectionString);
            command = new SqlCommand("INSERT INTO Categories(CategoryName) VALUES(@CategoryName)", connection);
            command.Parameters.AddWithValue("@CategoryName",category.CategoryName);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void UpdateCategory(Category category)
        {
            connection = new SqlConnection(connectionString);
            command = new SqlCommand("UPDATE Categories SET CategoryName=@CategoryName WHERE CategoryId=@CategoryId", connection);
            command.Parameters.AddWithValue("@CategoryId", category.CategoryId);
            command.Parameters.AddWithValue("@CategoryName", category.CategoryName);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public void DeleteCategory(Category category)
        {
            connection = new SqlConnection(connectionString);
            command = new SqlCommand("DELETE FROM Categories WHERE CategoryId=@CategoryId", connection);
            command.Parameters.AddWithValue("@CategoryId", category.CategoryId);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
