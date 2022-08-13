namespace WebApiApplication.DB
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using WebApiApplication.DB.Models;

    public class BloggingContext : DbContext, IBloggingContext
    {
        private IConfiguration _configuration;

        public DbSet<Blog>? Blogs { get; set; }
        public DbSet<Post>? Posts { get; set; }
        public DbSet<Tag>? Tags { get; set; }

        public BloggingContext(IConfiguration configuration) => _configuration = configuration;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(_configuration.GetConnectionString("BloggingContext"));
    }
}
