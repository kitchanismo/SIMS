using System.Data.Entity;

namespace DataAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Supplier> Supplier { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Customer> Customers { get; set; }

        
        public AppDbContext()
            :base("name=AppDbContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>()
                .HasRequired(p => p.Supplier)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SupplierID)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }

       
        
    }
}
