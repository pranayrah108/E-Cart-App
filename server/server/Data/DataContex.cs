using Microsoft.EntityFrameworkCore;
using server.Entities;

namespace server.Data
{
    public class DataContex:DbContext
    {

        public DataContex(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<User> users { get;set;}
        public DbSet<Brand> brand { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get;set; }
        public DbSet<ProductReview> productsReview { get; set; }
    }
}
