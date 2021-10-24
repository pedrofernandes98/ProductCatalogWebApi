using Microsoft.EntityFrameworkCore;
using ProductCatalogv2.Models;

namespace ProductCatalogv2.Data
{
    public class StoreDataContexts : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=DbProductCatalog;Data Source=LAPTOP-FJ79JN80\SQLEXPRESS");
        }

        protected override void OnModelCreating(ModelBuilder builder){
            builder.ApplyConfiguration(new CategoryMap());
            builder.ApplyConfiguration(new ProductMap());
        }
    }
}
