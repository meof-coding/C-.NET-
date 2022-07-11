using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q2
{
    class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public int Departmentid { get; set; }
    }
    class CourseDAL
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

            return config["ConnectionStrings:PRN292_Summer2020_B1"];
        }
        //Get Data from DB
        public List<Subject> GetSubject()
        {

            List<Subject> subjects = new List<Subject>();
            connection = new SqlConnection(GetConnectionString());
            command = new SqlCommand("select SubjectId,SubjectName from SUBJECTS inner join DEPARTMENTS on SUBJECTS.DepartmentId = DEPARTMENTS.DepartmentId", connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        subjects.Add(new Subject
                        {
                            SubjectId = reader.GetInt32("SubjectId"),
                            SubjectName = reader.GetString("SubjectName")
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
            return subjects;
        }
    }
}
