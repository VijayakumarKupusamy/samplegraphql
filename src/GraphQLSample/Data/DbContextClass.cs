using GraphQLSample.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLSample.Data
{
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> options) : base(options)
        {
        }

        public DbSet<Orders> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orders>()
                .HasKey(b => b.orderId);
        } 
    }
}
