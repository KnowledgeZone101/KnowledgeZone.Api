using KnowledgeZone.Domain.DTOs.Attendance;
using KnowledgeZone.Domain.Pagination;
using KnowledgeZone.Domain.ResourceParameters;

namespace KnowledgeZone.Domain.Interfaces.IServices
{
    public interface IAttendanceService
    {
        PaginatedList<AttendanceDto> GetAttendance(AttendanceResourceParameters attendanceResourceParameters);
        AttendanceDto? GetAttendanceById(int id);
        AttendanceDto CreateAttendance(AttendanceForCreateDto attendanceToCreate);
        void UpdateAttendance(AttendanceForUpdateDto attendanceToUpdate);
        void DeleteAttendance(int id);
    }
}
