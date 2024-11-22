using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DotNetBath14MTZO.HW03.ConsoleApp.EfCoreExamples.AppDbContext;

namespace DotNetBath14MTZO.HW03.ConsoleApp.EfCoreExamples
{
    public class EfCoreExample
    {
        private readonly AppDbContext _db = new AppDbContext();

        public void Read()
        {
            var list = _db.TblBlog.ToList();

            foreach (var item in list)
            {
                Console.WriteLine("BlodId******* " + item.Id);
                Console.WriteLine("BlogTitle******** " + item.Title);
                Console.WriteLine("BlogAuthor****** " +item.Author);
                Console.WriteLine("BlogContent******* " + item.Content);
            }
        }

        public void Edit(string id)
        {
            var item = _db.TblBlog.FirstOrDefault(x => x.Id == id);
            if (item is null)
            {

                Console.WriteLine("Data not Found");
                return;
            }

            Console.WriteLine("BlodId******* " + item.Id);
            Console.WriteLine("BlogTitle******** " + item.Title);
            Console.WriteLine("BlogAuthor****** " + item.Author);
            Console.WriteLine("BlogContent******* " + item.Content);


        }

        public void Create(string title, string author, string content)
        {
            var blog = new BlogTable()
            {
                Id = Guid.NewGuid().ToString(),
                Title = title,
                Author = author,
                Content = content
            };

            _db.TblBlog.Add(blog);
            var result = _db.SaveChanges();
            string message = result > 0 ? "Create is successful " : "Create is failed";
            Console.WriteLine(message);

        }

        public void Update(string id, string title, string author, string content)
        {
            var item = _db.TblBlog.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (item is null)
            {
                Console.WriteLine("Data Not Found");
                return;

            }

            item.Id = id;
            item.Title = title;
            item.Author = author;
            item.Content = content;
            _db.Entry(item).State = EntityState.Modified;
            var result = _db.SaveChanges();
            string message = result > 0 ? "Updating is successful" : "Updating is failed";
            Console.WriteLine(message);
        }
        public void Delete(string id)
        {
            var item = _db.TblBlog.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (item is null)
            {
                Console.WriteLine("Data not found");
                return;
            }

            _db.Entry(item).State = EntityState.Deleted;
            var result = _db.SaveChanges();
            string message = result > 0 ? "Deleting is successful" : "Deleting is failed";
            Console.WriteLine(message);
        }
    }
}
