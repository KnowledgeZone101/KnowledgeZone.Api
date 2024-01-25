using KnowledgeZone.Domain.DTOs.Attendance;
using KnowledgeZone.Domain.DTOs.Student;
using KnowledgeZone.Domain.Entities;
using KnowledgeZone.Domain.Interfaces.IServices;
using KnowledgeZone.Domain.Pagination;
using KnowledgeZone.Domain.ResourceParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KnowledgeZone.Api.Controllers
{
    [Route("api/Student")]
    [Authorize]
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

            var metaData = GetPagenationMetaData(student);

            Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(metaData));

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
        private PaginationMetaData GetPagenationMetaData(PaginatedList<StudentDto> studentDtOs)
        {
            return new PaginationMetaData
            {
                Totalcount = studentDtOs.TotalCount,
                PageSize = studentDtOs.PageSize,
                CurrentPage = studentDtOs.CurrentPage,
                TotalPages = studentDtOs.TotalPage,
            };
        }
    }
}
