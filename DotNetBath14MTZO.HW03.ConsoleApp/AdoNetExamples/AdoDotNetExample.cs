using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBath14MTZO.HW03.ConsoleApp.AdoNetExamples
{
    public class AdoDotNetExample
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "WalletDB",
            UserID = "sa",
            Password = "mtzoo@123",
            TrustServerCertificate = true
        };

        public void Read()
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("select * from Tbl_Blog", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("Blog Id is " + dr["BlogId"]);
                Console.WriteLine("Blog Title is " + dr["BlogTitle"]);
                Console.WriteLine("Blog Author is " + dr["BlogAuthor"]);
                Console.WriteLine("Blog Content is " + dr["BlogContent"]);
            }
        }
        public void Edit(string id)
        {
            SqlConnection sqlconnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);  
            sqlconnection.Open();
            SqlCommand cmd = new SqlCommand($"select * from Tbl_Blog where [BlogId]= '{id}'", sqlconnection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            sqlconnection.Close();

            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No Data found!!!");
                return;
            }
            DataRow dataRow = dt.Rows[0];
            Console.WriteLine("Blog Id is " + dataRow["BlogId"]);
            Console.WriteLine("Blog Title is " + dataRow["BlogTitle"]);
            Console.WriteLine("Blog Author is " + dataRow["BlogAuthor"]);
            Console.WriteLine("Blog Content is " + dataRow["BlogContent"]);

        }

        public void Create(string title,string author,string content)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString); 
           connection.Open();
            string query = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           ('{title}'
           ,'{author}'
           ,'{content}')";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            string message = result > 0 ? "Create Done!!!" : "Create Failed!!!";
            Console.WriteLine(message);
        }

        public void Update(string id, string title, string author, string content)
        {
            SqlConnection connect = new SqlConnection( _sqlConnectionStringBuilder.ConnectionString);
            connect.Open();
            string query = @$"UPDATE [dbo].[Tbl_Blog]
   SET [BlogId] = '{id}'
      ,[BlogTitle] = '{title}'
      ,[BlogAuthor] = '{author}'
      ,[BlogContent] = '{content}'
 WHERE [blogId]='{id}'";
            SqlCommand command = new SqlCommand(query, connect);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            int result = command.ExecuteNonQuery();

            connect.Close();

            string message = result > 0 ? "Update Complete !!!": "Update Failed";
            Console.WriteLine(message);
        }

        public void Delete(string id) {
            SqlConnection connect = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connect.Open();
            SqlCommand cmd = new SqlCommand($"delete from Tbl_Blog where [BlogId]='{id}'", connect);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            int result = cmd.ExecuteNonQuery ();
            connect.Close();
            string message = result > 0 ? "Delete Successful !!" : "Delete Failed !!";
            Console.WriteLine(message);

        }
     
    }
}
