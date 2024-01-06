using KnowledgeZone.Domain.Entities;

namespace KnowledgeZone.Domain.DTOs.Attendance
{
    public record AttendanceForUpdateDto(int AttendanceId, AttendanceType AttendanceType, Mark? Mark);
}
