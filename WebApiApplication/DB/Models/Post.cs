using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiApplication.DB.Models
{
    public class Post
    {
        [Key] 
        public int PostId { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string? Title { get; set; }

        [Column(TypeName = "varchar(200)")] 
        public string? Content { get; set; }

        public int BlogId { get; set; }
        public Blog? Blog { get; set; }

        public IEnumerable<Tag>? Tags { get; set; }
    }
}
