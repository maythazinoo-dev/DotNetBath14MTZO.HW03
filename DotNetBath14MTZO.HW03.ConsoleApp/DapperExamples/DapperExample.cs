using Dapper;
using DotNetBath14MTZO.HW03.ConsoleApp.DapperExamples.BlogDtos;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBath14MTZO.HW03.ConsoleApp.DapperExamples
{
    public class DapperExample
    {
        private readonly string _connectionString = AppSettings.SqlConnectionStringBuilder.ConnectionString;
        public void Read()
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            List<BlogDto> blogList=db.Query<BlogDto>("Select * from Tbl_Blog").ToList();

            foreach (BlogDto item in blogList)
            {
                Console.WriteLine("Blog Id = "+ item.BlogId);
                Console.WriteLine("Blog Title = "+ item.BlogTitle);
                Console.WriteLine("Blog Author = " + item.BlogAuthor);
                Console.WriteLine("Blog Content = " + item.BlogContent);
            }

        }

        public void Edit(string id)
        {
            using IDbConnection dbConnection = new SqlConnection(_connectionString);
            var item = dbConnection.Query<BlogDto>($"Select * from Tbl_blog where [BlogId]='{id}'").FirstOrDefault();

            if(item is null)
            {
                Console.WriteLine("Data not Found");
                return;
            }

            Console.WriteLine("Blog Id = " + item.BlogId);
            Console.WriteLine("Blog Title = " + item.BlogTitle);
            Console.WriteLine("Blog Author = " + item.BlogAuthor);
            Console.WriteLine("Blog Content = " + item.BlogContent);

        }

        public void Create(string title,string author,string content) 
        {
            string query = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           ('{title}'
           ,'{author}'
           ,'{content}')";

            using IDbConnection connection = new SqlConnection(_connectionString);
            int result = connection.Execute(query);
            string message = result > 0 ? "Creating Successful" : "Creating Failed";
            Console.WriteLine(message);
        }

        public void Update(string id, string title, string author,string content)
        {
            string query = $@"UPDATE [dbo].[Tbl_Blog]
   SET [BlogId] = '{id}'
      ,[BlogTitle] = '{title}'
      ,[BlogAuthor] = '{author}'
      ,[BlogContent] = '{content}'
 WHERE [BlogId]='{id}'";
            using IDbConnection connection = new SqlConnection(_connectionString);
            int result = connection.Execute(query);
            string message = result > 0 ? "Update is successful !!!" : "Update is failed";
            Console.WriteLine(message);
        }

        public void Delete(string id)
        {
            string query = $"DELETE FROM [dbo].[Tbl_Blog] WHERE [BlogId]='{id}'";
            using IDbConnection db = new SqlConnection(_connectionString);
            int result = db.Execute(query);
            string message = result > 0 ? "Delete  Done" : "Delete Failed";
            Console.WriteLine(message);

        }

    }
}
