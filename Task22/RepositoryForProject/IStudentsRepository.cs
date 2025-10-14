using ModelsForProject;

namespace RepositoryForProject
{
    public interface IStudentsRepository
    {
        Task<List<Students>> GetAllStudents();
        Task<Students?> GetStudentById(int id);
        Task<Students> AddStudent(Students student);
        string UpdateStudent(Students student);
        string DeleteStudent(int id);
    }
}
