using Microsoft.EntityFrameworkCore;
using Task20.Models;

namespace Task20.DataContext
{
    public class EmployeeDataContext : DbContext
    {
    public EmployeeDataContext(DbContextOptions<EmployeeDataContext> options) : base(options) { }
     public DbSet<Employee> Emp { get; set;}
    }
}
