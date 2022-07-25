using Microsoft.EntityFrameworkCore;
using OrdersApi.Core.Model;

namespace OrdersApi.Data
{
    public class OrderDBContext : DbContext
    {
        public DbSet<OrderModel> OrderModel { get; set; }
        public DbSet<AddressModel> AddressModel { get; set; }
        public DbSet<ProductModel> ProductModel { get; set; }

        public OrderDBContext(DbContextOptions<OrderDBContext> contextOptions) : base(contextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddressModel>().HasKey(x => x.Id);
            modelBuilder.Entity<OrderModel>().HasKey(x => x.Id);
            modelBuilder.Entity<OrderModel>().Property(x => x.UpdateAt).IsRequired(false);
            modelBuilder.Entity<ProductModel>().HasKey(x => x.Id);

            //one to one
            modelBuilder.Entity<OrderModel>()
                 .HasOne(s => s.Address)
                 .WithOne(ad => ad.Order)
                 .HasForeignKey<AddressModel>(x=>x.Id)
                 .IsRequired(true)
                 .OnDelete(DeleteBehavior.Cascade);

            //one to  many
            modelBuilder.Entity<OrderModel>()
                .HasMany(c => c.Product)
                .WithOne(e => e.Order)
                .HasForeignKey(x => x.OrderId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
