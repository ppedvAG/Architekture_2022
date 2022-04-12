using Microsoft.EntityFrameworkCore;
using ppedv.Foodybrät.Model;
using System;

namespace ppedv.Foodybrät.Data.EfCore
{
    public class EfContext : DbContext
    {
        private readonly string conString;

        public DbSet<Food> Food { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public EfContext(string conString = "Server=(localdb)\\mssqllocaldb;Database=Foodybrät_dev;Trusted_Connection=true;")
        {
            this.conString = conString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(conString).UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Food>().ToTable("Futter");

            modelBuilder.Entity<Customer>().Property(x => x.Address)
                                           .IsRequired()
                                           .HasColumnName("Adr")
                                           .HasMaxLength(500);

        }
    }
}
