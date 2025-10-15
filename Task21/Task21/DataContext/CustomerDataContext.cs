using System.Collections.Generic;
using Task21.Models;
using Microsoft.EntityFrameworkCore;

namespace Task21.DataContext
{
    public class CustomerDataContext : DbContext
    {

        public CustomerDataContext(DbContextOptions<CustomerDataContext> options) : base(options) { }

        public DbSet<Customer> customer { get; set; }
        public DbSet<Vendor> vendor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(
                    "Server=localhost;Port=3306;Database=Abstract;Uid=root;Pwd=root;",
                    new MySqlServerVersion(new Version(8, 0, 33))
                );
            }

        }

    }
}
