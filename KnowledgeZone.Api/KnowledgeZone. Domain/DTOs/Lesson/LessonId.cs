using KnowledgeZone.Domain.DTOs.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
