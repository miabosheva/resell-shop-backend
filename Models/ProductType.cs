using System.ComponentModel.DataAnnotations;

namespace backend_resell_app.Models
{
    public class ProductType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
