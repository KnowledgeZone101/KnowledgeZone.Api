using KnowledgeZone.Domain.DTOs.Attendance;
using KnowledgeZone.Domain.DTOs.Enrollment;
using KnowledgeZone.Domain.Entities;
using KnowledgeZone.Domain.Interfaces.IServices;
using KnowledgeZone.Domain.Pagination;
using KnowledgeZone.Domain.ResourceParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KnowledgeZone.Api.Controllers
{
    [Route("api/enrollment")]
    [ApiController]
    [Authorize]
    public class EnrollmentController : Controller
    {
        private readonly IEnrollmentService _enrollmentService;
        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EnrollmentDto>> GetEnrollments([FromQuery] EnrollmentResourceParamentrs enrollmentResourceParamentrs)
        {
            var enrollments = _enrollmentService.GetEnrollment(enrollmentResourceParamentrs);

            var metaData = GetPagenationMetaData(enrollments);

            Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(metaData));

            return Ok(enrollments);
        }

        [HttpGet("{id}", Name = "GetEnrollmentById")]
        public ActionResult<EnrollmentDto> GetEnrollment(int id)
        {
            var enrollment = _enrollmentService.GetEnrollmentById(id);

            return Ok(enrollment);
        }

        [HttpPost]
        public ActionResult Post([FromBody] EnrollmentForCreateDto enrollmentForCreateDto)
        {
            _enrollmentService.CreateEnrollment(enrollmentForCreateDto);

            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] EnrollmentForUpdateDto enrollmentForUpdateDto)
        {
            _enrollmentService.UpdateEnrollment(enrollmentForUpdateDto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _enrollmentService.DeleteEnrollment(id);

            return Ok();
        }
        private PagenationMetaData GetPagenationMetaData(PaginatedList<EnrollmentDto> enrollmentDtOs)
        {
            return new PagenationMetaData
            {
                Totalcount = enrollmentDtOs.TotalCount,
                PageSize = enrollmentDtOs.PageSize,
                CurrentPage = enrollmentDtOs.CurrentPage,
                TotalPages = enrollmentDtOs.TotalPage,
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
