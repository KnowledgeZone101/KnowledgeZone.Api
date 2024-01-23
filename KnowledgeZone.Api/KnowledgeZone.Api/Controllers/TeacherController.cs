using KnowledgeZone.Domain.DTOs.Attendance;
using KnowledgeZone.Domain.DTOs.Teacher;
using KnowledgeZone.Domain.Entities;
using KnowledgeZone.Domain.Interfaces.IServices;
using KnowledgeZone.Domain.Pagination;
using KnowledgeZone.Domain.ResourceParameters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KnowledgeZone.Api.Controllers
{
    [Route("api/teacher")]
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;
        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TeacherDto>> GetTeacher([FromQuery] TeacherResourceParamentrs teacherResourceParamentrs)
        {
            var teacher = _teacherService.GetTeacher(teacherResourceParamentrs);

            var metaData = GetPagenationMetaData(teacher);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metaData));

            return Ok(teacher);
        }

        [HttpGet("{id}", Name = "GetTeacherById")]
        public ActionResult<TeacherDto> Get(int id)
        {
            var teacher = _teacherService.GetTeacherById(id);

            return Ok(teacher);
        }

        [HttpPost]
        public ActionResult Post([FromBody] TeacherForCreateDto teacherForCreateDto)
        {
            _teacherService.CreateTeacher(teacherForCreateDto);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TeacherForUpdateDto teacherForUpdateDto)
        {
            _teacherService.UpdateTeacher(teacherForUpdateDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _teacherService.DeleteTeacher(id);

            return NoContent();
        }
        private PaginationMetaData GetPagenationMetaData(PaginatedList<TeacherDto> teacherDtOs)
        {
            return new PaginationMetaData
            {
                Totalcount = teacherDtOs.TotalCount,
                PageSize = teacherDtOs.PageSize,
                CurrentPage = teacherDtOs.CurrentPage,
                TotalPages = teacherDtOs.TotalPage,
            };
        }
    }
}
