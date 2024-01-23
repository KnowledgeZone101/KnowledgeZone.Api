using KnowledgeZone.Domain.DTOs.Attendance;
using KnowledgeZone.Domain.DTOs.Qualification;
using KnowledgeZone.Domain.Entities;
using KnowledgeZone.Domain.Interfaces.IServices;
using KnowledgeZone.Domain.Pagination;
using KnowledgeZone.Domain.ResourceParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KnowledgeZone.Api.Controllers
{
    [Route("api/qualification")]
    [ApiController]
    [Authorize]
    public class QualificationController : Controller
    {
        private readonly IQualificationService _qualificationService;
        public QualificationController(IQualificationService qualificationService)
        {
            _qualificationService = qualificationService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<QualificationDto>> GetQualification([FromQuery] QualificationResourceParamentrs qualificationResourceParamentrs)
        {
            var qualification = _qualificationService.GetQualification(qualificationResourceParamentrs);

            var metaData = GetPagenationMetaData(qualification);

            Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(metaData));

            return Ok(qualification);
        }

        [HttpGet("{id}", Name = "GetQualificationById")]
        public ActionResult<QualificationDto> Get(int id)
        {
            var qualification = _qualificationService.GetQualificationById(id);

            return Ok(qualification);
        }

        [HttpPost]
        public ActionResult Post([FromBody] QualificationForCreateDto qualificationForCreateDto)
        {
            _qualificationService.CreateQualification(qualificationForCreateDto);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] QualificationForUpdateDto qualificationForUpdateDto)
        {
            _qualificationService.UpdateQualification(qualificationForUpdateDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _qualificationService.DeleteQualification(id);

            return NoContent();
        }
        private PagenationMetaData GetPagenationMetaData(PaginatedList<QualificationDto> qualificationDtOs)
        {
            return new PagenationMetaData
            {
                Totalcount = qualificationDtOs.TotalCount,
                PageSize = qualificationDtOs.PageSize,
                CurrentPage =  qualificationDtOs.CurrentPage,
                TotalPages = qualificationDtOs.TotalPage,
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
