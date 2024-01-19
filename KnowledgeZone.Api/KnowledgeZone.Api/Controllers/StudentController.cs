using KnowledgeZone.Domain.DTOs.Attendance;
using KnowledgeZone.Domain.DTOs.Student;
using KnowledgeZone.Domain.Entities;
using KnowledgeZone.Domain.Interfaces.IServices;
using KnowledgeZone.Domain.Pagination;
using KnowledgeZone.Domain.ResourceParameters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

            var metaData = GetPagenationMetaData(student);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metaData));

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
        private PagenationMetaData GetPagenationMetaData(PaginatedList<StudentDto> studentDtOs)
        {
            return new PagenationMetaData
            {
                Totalcount = studentDtOs.TotalCount,
                PageSize = studentDtOs.PageSize,
                CurrentPage = studentDtOs.CurrentPage,
                TotalPages = studentDtOs.TotalPage,
            };
        }
        class PagenationMetaData
        {
            public int Totalcount { get; set; }
            public int PageSize { get; set; }
            public int CurrentPage { get; set; }
            public int TotalPages { get; set; }
        }
    }
}
