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
           modelBuilder.Entity<AddressModel>()
                .HasOne(s => s.Customer) 
                .WithOne(ad => ad.Address)
                .HasForeignKey<CustomerModel>(x=>x.AddressId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
