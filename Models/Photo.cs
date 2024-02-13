using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_resell_app.Models
{
    [Table("Photos")]
    public class Photo
    {
        public int Id { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public bool IsPrimary { get; set; } 
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}