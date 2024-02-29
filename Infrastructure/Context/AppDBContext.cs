using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class AppDBContext : IdentityDbContext<AppUser>
    {
        public AppDBContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");

            builder.Entity<ProductInfo>().ToTable("ProductInfo");
            builder.Entity<Product>().ToTable("Products");
           



           // builder.Entity<Invoice>().HasMany(i=>i.Products)
        }
        public DbSet<Product> Products{ get; set; }
        public DbSet<ProductInfo>  ProductInfos{ get; set; }
        public DbSet<Supplier> Suppliers{ get; set; }
        public DbSet<Invoice>  Invoices{ get; set; }
        public DbSet<Purchase> Purchases  { get; set; }
    }
}
