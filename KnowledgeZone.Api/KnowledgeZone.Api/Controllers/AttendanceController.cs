using KnowledgeZone.Domain.DTOs.Attendance;
using KnowledgeZone.Domain.Interfaces.IServices;
using KnowledgeZone.Domain.ResourceParameters;
using Microsoft.AspNetCore.Mvc;

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
    }
}
