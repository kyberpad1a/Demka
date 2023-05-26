using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DEmka
{
    public partial class TradeDB : DbContext
    {
        public static TradeDB _context;
        public TradeDB()
            : base("name=TradeData")
        {
        }
        public static TradeDB GetContext()
        {
            if (_context == null)
            {
                _context = new TradeDB();
            }
            return _context;
        }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<PointPickup> PointPickups { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasMany(e => e.Products)
                .WithMany(e => e.Orders)
                .Map(m => m.ToTable("OrderProduct").MapLeftKey("OrderID").MapRightKey("ProductArticleNumber"));

            modelBuilder.Entity<PointPickup>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.PointPickup)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ProductCost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Role)
                .HasForeignKey(e => e.UserRole)
                .WillCascadeOnDelete(false);
        }
    }
}
