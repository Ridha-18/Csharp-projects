using Microsoft.AspNetCore.Mvc;
using ModelsForProject;
using RepositoryForProject;

namespace Task22.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsRepository _studentsRepository;

        public StudentsController(IStudentsRepository studentsRepository)
        {
            _studentsRepository = studentsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentsRepository.GetAllStudents();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _studentsRepository.GetStudentById(id);
            if (student == null)
                return NotFound();

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(Students student)
        {
            var newStudent = await _studentsRepository.AddStudent(student);
            return CreatedAtAction(nameof(GetStudentById), new { id = newStudent.Id }, newStudent);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, Students student)
        {
            if (id != student.Id)
                return BadRequest();

            var result = _studentsRepository.UpdateStudent(student);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var result = _studentsRepository.DeleteStudent(id);
            if (result == "Student not found")
                return NotFound(result);

            return Ok(result);
        }
    }
}