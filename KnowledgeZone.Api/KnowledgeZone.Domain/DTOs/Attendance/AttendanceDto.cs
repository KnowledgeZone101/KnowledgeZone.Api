using KnowledgeZone.Domain.DTOs.Lesson;
using KnowledgeZone.Domain.Entities;

namespace KnowledgeZone.Domain.DTOs.Attendance
{
    public record AttendanceDto(int AttendanceId, int StudentId, AttendanceType AttendanceType, Mark? Mark, int LessonId, LessonDto Lesson);
}
