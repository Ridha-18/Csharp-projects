using Task17.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task17.DataContext
{
    public class StudentDataContext : DbContext
    {
        public StudentDataContext() { }

        public StudentDataContext(DbContextOptions<StudentDataContext> options) : base(options) { }

        public DbSet<Student> students { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(
                    "Server=localhost;Port=3306;Database=StudentPortal;Uid=root;Pwd=root;",
                    new MySqlServerVersion(new Version(8, 0, 33))
                );
            }

        }
        

    }
}
