using KnowledgeZone.Domain.Entities;

namespace KnowledgeZone.Domain.DTOs.Attendance
{
    public record AttendanceForCreateDto(int StudentId, AttendanceType AttendanceType, int LessonId);

}
