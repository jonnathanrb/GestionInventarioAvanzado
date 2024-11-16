using GestionInventarioAvanzado.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionInventarioAvanzado.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // Entities
        public DbSet<Provider> Providers { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<InventoryMovement> InventoryMovements { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .Property(e => e.Status);

            modelBuilder.Entity<Order>()
            .HasMany(o => o.OrderItems)
            .WithOne(d => d.Order)
            .HasForeignKey(d => d.OrderId); // Define la clave foránea en DetalleOrden

            modelBuilder.Entity<OrderItem>()
            .HasOne(d => d.Order)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(d => d.OrderId)
            .OnDelete(DeleteBehavior.Restrict); // Evita la cascada de eliminación
        }
    }
}
