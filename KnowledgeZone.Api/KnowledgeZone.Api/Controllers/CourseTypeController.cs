using KnowledgeZone.Domain.DTOs.Attendance;
using KnowledgeZone.Domain.DTOs.CourseType;
using KnowledgeZone.Domain.Entities;
using KnowledgeZone.Domain.Interfaces.IServices;
using KnowledgeZone.Domain.Pagination;
using KnowledgeZone.Domain.ResourceParameters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

            var metaData = GetPagenationMetaData(courseTypes);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metaData));

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

        private PagenationMetaData GetPagenationMetaData(PaginatedList<CourseTypeDto> courseTypeDtOs)
        {
            return new PagenationMetaData
            {
                Totalcount = courseTypeDtOs.TotalCount,
                PageSize = courseTypeDtOs.PageSize,
                CurrentPage = courseTypeDtOs.CurrentPage,
                TotalPages = courseTypeDtOs.TotalPage,
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
