

namespace KnowledgeZone.Domain.DTOs.Lesson
{
    public record LessonForCreateDto(
        DateTime StartTime,
        DateTime FinishTime,
        int RoomId,
        int CourseId,
        int AttendanceId);
}
