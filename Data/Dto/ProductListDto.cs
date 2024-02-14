using backend_resell_app.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_resell_app.Data.Dto
{
    public class ProductListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ProductType { get; set; }
        public string Size { get; set; }
        public int Price { get; set; }
        public string ConditionType { get; set; }
        public string Username { get; set; }
        public int? Year { get; set; }
        public string? Description { get; set; }
    }
}
