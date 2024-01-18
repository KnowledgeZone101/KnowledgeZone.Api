using KnowledgeZone.Domain.DTOs.Student;
using KnowledgeZone.Domain.Interfaces.IServices;
using KnowledgeZone.Domain.ResourceParameters;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeZone.Api.Controllers
{
    [Route("api/Student")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<StudentDto>> GetStudent([FromQuery] StudentResourceParamentrs studentResourceParamentrs)
        {
            var student = _studentService.GetStudent(studentResourceParamentrs);

            return Ok(student);
        }

        [HttpGet("{id}", Name = "GetStudentById")]
        public ActionResult<StudentDto> Get(int id)
        {
            var student = _studentService.GetStudentById(id);

            return Ok(student);
        }

        [HttpPost]
        public ActionResult Post([FromBody] StudentForCreateDto studentForCreateDto)
        {
            _studentService.CreateStudent(studentForCreateDto);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] StudentForUpdateDto studentForUpdateDto)
        {
            _studentService.UpdateStudent(studentForUpdateDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _studentService.DeleteStudent(id);

            return NoContent();
        }
    }
}
