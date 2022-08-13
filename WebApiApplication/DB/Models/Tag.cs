using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiApplication.DB.Models
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }
        [Column(TypeName = "varchar(200)")] 
        public string? Title { get; set; }
    }
}
