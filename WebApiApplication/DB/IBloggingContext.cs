using Microsoft.EntityFrameworkCore;
using WebApiApplication.DB.Models;

namespace WebApiApplication.DB
{
    public interface IBloggingContext
    {

        int SaveChanges();

        int SaveChanges(bool acceptAllChangesOnSuccess);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        
        DbSet<Blog>? Blogs { get; set; }
        DbSet<Post>? Posts { get; set; }
        DbSet<Tag>? Tags { get; set; }
    }
}