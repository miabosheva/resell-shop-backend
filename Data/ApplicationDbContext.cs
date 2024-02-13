using backend_resell_app.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace backend_resell_app.Data
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductConditionType> ConditionTypes { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public static implicit operator SplitQueryDataReaderContext(ApplicationDbContext v)
        {
            throw new NotImplementedException();
        }
    }
}