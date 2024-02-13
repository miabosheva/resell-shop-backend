using System.ComponentModel.DataAnnotations;

namespace backend_resell_app.Models
{
    public class ProductConditionType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
