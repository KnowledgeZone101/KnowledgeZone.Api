

namespace KnowledgeZone.Domain.DTOs.Lesson
{
    public record LessonForUpdateDto(
        int LessonId,
        DateTime StartTime,
        DateTime FinishTime,
        int RoomId,
        int CourseId,
        int AttendanceId);
}
