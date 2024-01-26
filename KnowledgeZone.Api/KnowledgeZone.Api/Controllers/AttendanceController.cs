using KnowledgeZone.Domain.DTOs.Attendance;
using KnowledgeZone.Domain.Interfaces.IServices;
using KnowledgeZone.Domain.Pagination;
using KnowledgeZone.Domain.ResourceParameters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KnowledgeZone.Api.Controllers
{
    [Route("api/attendance")]
    [ApiController]
    public class AttendanceController : Controller
    {
        private readonly IAttendanceService _attendanceService;
        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AttendanceDto>> GetAttendance([FromQuery] AttendanceResourceParameters attendanceResourceParameters)
        {
            var attendance = _attendanceService.GetAttendance(attendanceResourceParameters);

            var metaData = GetPagenationMetaData(attendance);

            Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(metaData));

            return Ok(attendance);
        }

        [HttpGet("{id}", Name = "GetAttendanceById")]
        public ActionResult<AttendanceDto> Get(int id)
        {
            var attendance = _attendanceService.GetAttendanceById(id);

            return Ok(attendance);
        }

        [HttpPost]
        public ActionResult Post(AttendanceForCreateDto attendanceForCreateDto)
        {
            _attendanceService.CreateAttendance(attendanceForCreateDto);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] AttendanceForUpdateDto attendanceForUpdateDto)
        {
            _attendanceService.UpdateAttendance(attendanceForUpdateDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _attendanceService.DeleteAttendance(id);

            return NoContent();
        }
        private PaginationMetaData GetPagenationMetaData(PaginatedList<AttendanceDto> attendanceDtOs)
        {
            return new PaginationMetaData
            {
                Totalcount = attendanceDtOs.TotalCount,
                PageSize = attendanceDtOs.PageSize,
                CurrentPage = attendanceDtOs.CurrentPage,
                TotalPages = attendanceDtOs.TotalPage,
            };
        }
    }
}
