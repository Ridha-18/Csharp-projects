using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModelsForProject;

namespace ContextForProject
{
    public class StudentsCoursesDataContext : DbContext
    {
        public StudentsCoursesDataContext(DbContextOptions<StudentsCoursesDataContext> options)
            : base(options)
        {
        }

        public DbSet<Students> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed some courses
            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Name = "Mathematics", Description = "Basic Math Course" },
                new Course { Id = 2, Name = "Physics", Description = "Intro to Physics" }
            );
        }
    }
}
