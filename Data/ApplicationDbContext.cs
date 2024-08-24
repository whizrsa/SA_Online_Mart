using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using SA_Online_Mart.Models;

namespace SA_Online_Mart.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
        
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShippingDetail> ShippingDetails { get; set; }
        public DbSet<PaymentDetail> PaymentDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var admin = new IdentityRole("admin")
            {
                NormalizedName = "ADMIN"
            };


            var customer = new IdentityRole("customer")
            {
                NormalizedName = "CUSTOMER"
            };
            

            modelBuilder.Entity<IdentityRole>().HasData(admin, customer);

            //
            modelBuilder.Entity<Cart>()
            .HasOne(c => c.User)
            .WithMany(u => u.ShoppingCartItems)
            .HasForeignKey(c => c.UserId)
            .IsRequired(); // Ensures UserId is a required foreign key

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.Product)
                .WithMany(p => p.ShoppingCartItems)
                .HasForeignKey(c => c.ProductId)
                .IsRequired(); // Ensures ProductId is a required foreign key

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .IsRequired(); // Ensures UserId is a required foreign key

            // Configure decimal properties
            modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<OrderItem>()
                .Property(oi => oi.UnitPrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<PaymentDetail>()
                .Property(pd => pd.AmountPaid)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

        }
    }
}
