using KnowledgeZone.Domain.DTOs.Attendance;
using KnowledgeZone.Domain.DTOs.Course;
using KnowledgeZone.Domain.DTOs.Room;


namespace KnowledgeZone.Domain.DTOs.Lesson
{
    public record LessonDto(
        int LessonId,
        DateTime StartTime,
        DateTime FinishTime,
        int RoomId,
        RoomDto Room,
        int CourseId,
        CourseDto Course,
        int AttendanceId,
        AttendanceDto Attendance);
}
