using System.ComponentModel.DataAnnotations.Schema;

namespace backend_resell_app.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }

        [ForeignKey("User")]
        public int Auhtor { get; set; }
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
        public string Size { get; set; }
        public int Price { get; set; }
        public int ConditionTypeId { get; set; }
        public ProductConditionType ConditionType { get; set; }
        public int? Year { get; set; }
        public ICollection<Photo>? Photos { get; set; }
        public string? Description { get; set; }
    }
}
