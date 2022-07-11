using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace PRN292_Sum2020_B5
{
    class Book
    {
        public string BookName { get; set; }

        public int Year { get; set; }

        public string Author { get; set; }
    }
    class BookDAL
    {
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

            return config["ConnectionStrings:PRN292_Sum2020_B5"];
        }
        //Get Data from DB
        public List<Book> GetBook()
        {

            List<Book> products = new List<Book>();
            connection = new SqlConnection(GetConnectionString());
            command = new SqlCommand("with table1 as(select Title, [Year],BookID from Books inner join Author_Book on Author_Book.BookID = Books.ID) select table1.Title, table1.[Year], b.[Name] from table1 inner join (select [Name], BookID from Authors inner join Author_Book on Authors.ID = Author_Book.AuthorID) as b on table1.BookID = b.BookID", connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        products.Add(new Book
                        {
                            BookName = reader.GetString("Title"),
                            Year = reader.GetInt32("Year"),
                            Author = reader.GetString("Name"),
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

        public List<string> GetAuthor(string name)
        {

            List<string> author = new List<string>();
            connection = new SqlConnection(GetConnectionString());
            command = new SqlCommand("with Mytabble as(select Title, [Year],BookID from Books inner join Author_Book on Author_Book.BookID = Books.ID) select Mytabble.Title, Mytabble.[Year], b.[Name] from Mytabble inner join (select [Name], BookID from Authors inner join Author_Book on Authors.ID = Author_Book.AuthorID) as b on Mytabble.BookID = b.BookID where Mytabble.Title = @title", connection);
            command.Parameters.AddWithValue("@title", name);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        author.Add(reader.GetString("Name"));
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
            return author.Distinct().ToList();
        }

        public List<int> GetYear(string name)
        {

            List<int> year = new List<int>();
            connection = new SqlConnection(GetConnectionString());
            command = new SqlCommand("with Mytabble as(select Title, [Year],BookID from Books inner join Author_Book on Author_Book.BookID = Books.ID) select Mytabble.Title, Mytabble.[Year], b.[Name] from Mytabble inner join (select [Name], BookID from Authors inner join Author_Book on Authors.ID = Author_Book.AuthorID) as b on Mytabble.BookID = b.BookID where Mytabble.Title = @title", connection);
            command.Parameters.AddWithValue("@title", name);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        year.Add(reader.GetInt32("Year"));
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
            return year.Distinct().ToList();
        }

        public int GetBookID(string name)
        {

            int result=0;
            connection = new SqlConnection(GetConnectionString());
            command = new SqlCommand("select ID from Books where Title = @name", connection);
            command.Parameters.AddWithValue("@name", name);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        result=reader.GetInt32("ID");
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
            return result;
        }

        public int GetAuthorID(string name)
        {

            int result = 0;
            connection = new SqlConnection(GetConnectionString());
            command = new SqlCommand("select ID from Authors where [Name] = @name", connection);
            command.Parameters.AddWithValue("@name", name);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        result = reader.GetInt32("ID");
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
            return result;
        }

        //Delete
        public int DeleteAuthor(int authorId, int bookID)
        {
            int result = 0;
            connection = new SqlConnection(GetConnectionString());
            command = new SqlCommand("delete from Author_Book where AuthorID = @auID and BookID =@bID", connection);
            command.Parameters.AddWithValue("@auID", authorId);
            command.Parameters.AddWithValue("@bID", bookID);
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
