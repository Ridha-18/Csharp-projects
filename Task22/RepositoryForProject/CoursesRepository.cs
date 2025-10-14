using ContextForProject;
using Microsoft.EntityFrameworkCore;
using ModelsForProject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryForProject
{
    public class CoursesRepository : ICoursesRepository
    {
        private readonly StudentsCoursesDataContext _context;

        public CoursesRepository(StudentsCoursesDataContext context)
        {
            _context = context;
        }

        public async Task<List<Course>> GetAllCourses()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course?> GetCourseById(int id)
        {
            return await _context.Courses.FindAsync(id);
        }

        public async Task<Course> AddCourse(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public string UpdateCourse(Course course)
        {
            _context.Entry(course).State = EntityState.Modified;
            _context.SaveChanges();
            return "Course updated successfully";
        }

        public string DeleteCourse(int id)
        {
            var course = _context.Courses.Find(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
                return "Course deleted successfully";
            }
            return "Course not found";
        }
    }
}