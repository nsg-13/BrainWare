using System.Data.Entity;

using BrainWare.Data.Entities;

namespace BrainWare.Data
{
    public partial class BrainWareContext : DbContext
    {
        public BrainWareContext()
            : base("name=BrainWareContext")
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderProduct> orderproducts { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Company>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Company)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderProducts)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderProducts)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);
        }
    }
}
