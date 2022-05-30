using DomainLayer.Model;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Extension;

namespace RepositoryLayer.DbContextLayer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions con) : base(con)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Product>()
                        .HasOne<Category>(c => c.Category)
                        .WithMany(p => p.Products)
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasForeignKey(c => c.CategoryID);*/
            new ProductEntityTypeConfiguration().Configure(modelBuilder.Entity<Product>());
            new UserRoleEntityConfig().Configure(modelBuilder.Entity<User_Role>());
            modelBuilder.Seed();
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<User_Role> User_Role { get; set; }


    }
}
