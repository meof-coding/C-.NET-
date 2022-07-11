using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Q3
{
    public class TestResult
    {
        public string StudentID { get; set; }
        public string StudentName { get; set; }
        public string Subject { get; set; }
        public string TestType { get; set; }
        public DateTime date { get; set; }
        public decimal Mark { get; set; }
    }


    public class TestResultDAO
    {
        // Khai báo đối tượng kết nối
        SqlConnection connection;
        // Khai báo đối tượng thực thi các truy vấn
        SqlCommand command;

        // Phương thức lấy chuỗi kết nối từ appsettings.json
        string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            return config["ConnectionStrings:MyTestDB"];
        }

        public int insertTest(TestResult tr)
        {
            int result = 0;

            connection = new SqlConnection(GetConnectionString());
            string sql = "insert into TestResult values (@ID, @Name, @Subject, @Type, @Date, @Mark)";
            command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@ID", tr.StudentID);
            command.Parameters.AddWithValue("@Name", tr.StudentName);
            command.Parameters.AddWithValue("@Subject", tr.Subject);
            command.Parameters.AddWithValue("@Type", tr.TestType);
            command.Parameters.AddWithValue("@Date", tr.date);
            command.Parameters.AddWithValue("@Mark", tr.Mark);

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
