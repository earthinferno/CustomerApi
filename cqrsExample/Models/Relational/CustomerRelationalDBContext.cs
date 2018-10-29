using Microsoft.EntityFrameworkCore;

namespace CustomerApi.Models.Relational
{
    public class CustomerRelationalDBContext : DbContext
    {
        public CustomerRelationalDBContext (DbContextOptions<CustomerRelationalDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerRecord>().HasMany(x => x.Phones);
        }

        public DbSet<CustomerRecord> Customers { get; set; }
    }
}
