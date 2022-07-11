using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace PE19SpringB5_1
{
    class Corporation
    {
        public int Corporation_No { get; set; }

        public string Corporation_Name { get; set; }

        public string Street { get; set; }

        public string Region_Name { get; set; }


    }
    class Cor_DAL
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

            return config["ConnectionStrings:PRN292_19_Spring"];
        }

        //Get Data from DB
        public List<Corporation> GetCor()
        {

            List<Corporation> corporations = new List<Corporation>();
            connection = new SqlConnection(GetConnectionString());
            command = new SqlCommand("select corporation.corp_no, corporation.corp_name, corporation.street, region_name from corporation inner join region on corporation.region_no = region.region_no", connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        corporations.Add(new Corporation
                        {
                            Corporation_No = reader.GetInt32("corp_no"),
                            Corporation_Name = reader.GetString("corp_name"),
                            Street = reader.GetString("street"),
                            Region_Name = reader.GetString("region_name"),
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
            return corporations;
        }

        public int DeleteMultipleCorporation(string index)
        {
            string query = $"delete from member where corp_no in ({index})\ndelete from corporation where corp_no in ({index})";
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

        public DateTime GetSpecific_Date(int corp_no)
        {
            DateTime result = new DateTime();
            connection = new SqlConnection(GetConnectionString());
            command = new SqlCommand("select expr_dt from corporation where corp_no= @corp_no", connection);
            command.Parameters.AddWithValue("@corp_no", corp_no);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                    {
                        result = reader.GetDateTime("expr_dt");
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

        public int UpdateInfoCor(string name,string street,string dateTime,int key)
        {
            int result = 0;
            connection = new SqlConnection(GetConnectionString());
            command = new SqlCommand("update corporation set corp_name = @old_name,street = @street,expr_dt= @datetime where corp_no = @key", connection);
            command.Parameters.AddWithValue("@old_name", name);
            command.Parameters.AddWithValue("@street", street);
            command.Parameters.AddWithValue("@datetime", dateTime);
            command.Parameters.AddWithValue("@key", key);
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
