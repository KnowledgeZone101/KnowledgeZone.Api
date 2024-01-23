using KnowledgeZone.Domain.DTOs.Attendance;
using KnowledgeZone.Domain.DTOs.Course;
using KnowledgeZone.Domain.Entities;
using KnowledgeZone.Domain.Interfaces.IServices;
using KnowledgeZone.Domain.Pagination;
using KnowledgeZone.Domain.ResourceParameters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KnowledgeZone.Api.Controllers
{
    [Route("api/course")]
    [ApiController]
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService; 
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CourseDto>> GetCourese([FromQuery] CourseResourceParamentrs courseResourceParamentrs)
        {
            var courses = _courseService.GetCourse(courseResourceParamentrs);

            var metaData = GetPagenationMetaData(courses);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metaData));

            return Ok(courses);
        }

        [HttpGet("{id}", Name = "GetCourseById")]
        public ActionResult<CourseDto> GetCourse(int id)
        {
            var course = _courseService.GetCourseById(id);

            return Ok(course);
        }

        [HttpPost]
        public ActionResult Post([FromBody] CourseForCreateDto courseForCreateDto)
        {
            _courseService.CreateCourse(courseForCreateDto);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CourseForUpdateDto courseForUpdateDto)
        {
            _courseService.UpdateCourse(courseForUpdateDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _courseService.DeleteCourse(id);

            return NoContent();
        }
        private PaginationMetaData GetPagenationMetaData(PaginatedList<CourseDto> courseDtOs)
        {
            return new PaginationMetaData
            {
                Totalcount = courseDtOs.TotalCount,
                PageSize = courseDtOs.PageSize,
                CurrentPage = courseDtOs.CurrentPage,
                TotalPages = courseDtOs.TotalPage,
            };
        }
    }
}
