using ContextForProject;
using Microsoft.EntityFrameworkCore;
using ModelsForProject;

namespace RepositoryForProject
{
    public class StudentsRepository : IStudentsRepository
    {
        private readonly StudentsCoursesDataContext _context;

        public StudentsRepository(StudentsCoursesDataContext context)
        {
            _context = context;
        }

        public async Task<List<Students>> GetAllStudents()
        {
            return await _context.Students.Include(s => s.Course).ToListAsync();
        }

        public async Task<Students?> GetStudentById(int id)
        {
            return await _context.Students.Include(s => s.Course)
                                          .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Students> AddStudent(Students student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public string UpdateStudent(Students student)
        {
            _context.Entry(student).State = EntityState.Modified;
            _context.SaveChanges();
            return "Updated successfully";
        }

        public string DeleteStudent(int id)
        {
            var student = _context.Students.Find(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
                return "Deleted successfully";
            }
            return "Student not found";
        }
    }
}
