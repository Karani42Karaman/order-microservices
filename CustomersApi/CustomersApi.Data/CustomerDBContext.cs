using CustomersApi.Core.Model;
using Microsoft.EntityFrameworkCore;


namespace CustomersApi.Data
{
    public class CustomerDBContext : DbContext
    {
        public DbSet<CustomerModel> CustomerModel { get; set; }
        public DbSet<AddressModel> AddressModel { get; set; }

        public CustomerDBContext(DbContextOptions<CustomerDBContext> contextOptions) : base(contextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddressModel>().HasKey(x => x.Id);
            modelBuilder.Entity<CustomerModel>().HasKey(x => x.Id);
            modelBuilder.Entity<CustomerModel>().Property(x=>x.UpdateAt).IsRequired(false);



            modelBuilder.Entity<CustomerModel>()
                 .HasOne(s => s.Address)
                 .WithOne(ad => ad.Customer)
                 .HasForeignKey<AddressModel>()
                 .IsRequired(true)
                 .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
