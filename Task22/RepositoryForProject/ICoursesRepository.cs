using ModelsForProject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryForProject
{
    public interface ICoursesRepository
    {
        Task<List<Course>> GetAllCourses();
        Task<Course?> GetCourseById(int id);
        Task<Course> AddCourse(Course course);
        string UpdateCourse(Course course);
        string DeleteCourse(int id);
    }
}
