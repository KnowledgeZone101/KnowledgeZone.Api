using KnowledgeZone.Domain.DTOs.CourseType;
using KnowledgeZone.Domain.Interfaces.IServices;
using KnowledgeZone.Domain.ResourceParameters;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeZone.Api.Controllers
{
    [Route("api/courseType")]
    [ApiController]
    public class CourseTypeController : Controller
    {
        private readonly ICourseTypeService _courseTypeService;
        public CourseTypeController(ICourseTypeService courseTypeService)
        {
            _courseTypeService = courseTypeService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CourseTypeDto>> GetCouseType([FromQuery] CourseTypeResourceParamentrs courseTypeResourceParamentrs)
        {
            var courseTypes = _courseTypeService.GetCourseType(courseTypeResourceParamentrs);

            return Ok(courseTypes);
        }

        [HttpGet("{id}", Name = "GetCouseTypeById")]
        public ActionResult<CourseTypeDto> Get(int id)
        {
            var courseType = _courseTypeService.GetCourseTypeById(id);
            
            return Ok(courseType);
        }

        [HttpPost]
        public ActionResult Post([FromBody] CourseTypeForCreateDto courseTypeForCreateDto)
        {
            _courseTypeService.CreateCourseType(courseTypeForCreateDto);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CourseTypeForUpdateDto courseTypeForUpdateDto)
        {
            _courseTypeService.UpdateCourseType(courseTypeForUpdateDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _courseTypeService.DeleteCourseType(id);

            return NoContent();
        }
    }
}
