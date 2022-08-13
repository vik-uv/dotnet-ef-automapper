using WebApiApplication.DB.Models;

namespace WebApiApplication.DB
{
    public class Seeder
    {
        public static void SeedData(IBloggingContext dbContext)
        {
            if (dbContext?.Posts?.Any() == true)
            {
                return;
            }

            Console.WriteLine("Seeding data");
            dbContext.Blogs.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
            dbContext.Posts.Add(new Post { BlogId = 1, Content = "It's a new post", Title = "Post1", Tags = new Tag[] { new Tag { Title = "data" }, new Tag { Title = "first" } } });
            dbContext.Posts.Add(new Post { BlogId = 1, Content = "Another post about nothing", Title = "Post2", Tags = new Tag[] { new Tag { Title = "second" } } });
            dbContext.SaveChanges();
        } 
    }
}
