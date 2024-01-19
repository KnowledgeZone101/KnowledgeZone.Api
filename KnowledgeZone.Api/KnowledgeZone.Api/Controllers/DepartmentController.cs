using KnowledgeZone.Domain.DTOs.Attendance;
using KnowledgeZone.Domain.DTOs.Department;
using KnowledgeZone.Domain.Entities;
using KnowledgeZone.Domain.Interfaces.IServices;
using KnowledgeZone.Domain.Pagination;
using KnowledgeZone.Domain.ResourceParameters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KnowledgeZone.Api.Controllers
{
    [Route("api/department")]
    [ApiController]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DepartmentDto>> GetDepartments([FromQuery] DepartmentResourceParamentrs departmentResourceParamentrs)
        {
            var departments = _departmentService.GetDepartment(departmentResourceParamentrs);

            var metaData = GetPagenationMetaData(departments);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metaData));

            return Ok(departments);
        }

        [HttpGet("{id}", Name = "GetDepartmentById")]
        public ActionResult<DepartmentDto> Get(int id)
        {
            var department = _departmentService.GetDepartmentById(id);

            return Ok(department);
        }

        [HttpPost]
        public ActionResult Post([FromBody] DepartmentForCreateDto departmentForCreateDto)
        {
            _departmentService.CreateDepartment(departmentForCreateDto);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] DepartmentForUpdateDto departmentForUpdateDto)
        {
            _departmentService.UpdateDepartment(departmentForUpdateDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _departmentService.DeleteDepartment(id);

            return NoContent();
        }
        private PagenationMetaData GetPagenationMetaData(PaginatedList<DepartmentDto> departmentDtOs)
        {
            return new PagenationMetaData
            {
                Totalcount = departmentDtOs.TotalCount,
                PageSize = departmentDtOs.PageSize,
                CurrentPage = departmentDtOs.CurrentPage,
                TotalPages = departmentDtOs.TotalPage,
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
