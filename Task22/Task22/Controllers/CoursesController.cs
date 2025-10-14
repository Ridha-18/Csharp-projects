using Microsoft.AspNetCore.Mvc;
using ModelsForProject;
using RepositoryForProject;
using System.Threading.Tasks;

namespace Task22.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICoursesRepository _repository;

        public CoursesController(ICoursesRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await _repository.GetAllCourses();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await _repository.GetCourseById(id);
            if (course == null)
                return NotFound();

            return Ok(course);
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse(Course course)
        {
            var newCourse = await _repository.AddCourse(course);
            return CreatedAtAction(nameof(GetCourseById), new { id = newCourse.Id }, newCourse);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCourse(int id, Course course)
        {
            if (id != course.Id)
                return BadRequest();

            var result = _repository.UpdateCourse(course);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {
            var result = _repository.DeleteCourse(id);
            return Ok(result);
        }
    }
}
