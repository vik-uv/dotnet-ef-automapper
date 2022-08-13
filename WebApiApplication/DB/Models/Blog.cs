using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiApplication.DB.Models
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }
        
        [Column(TypeName = "varchar(200)")]
        public string? Url { get; set; }

        public List<Post> Posts { get; } = new();
    }
}
