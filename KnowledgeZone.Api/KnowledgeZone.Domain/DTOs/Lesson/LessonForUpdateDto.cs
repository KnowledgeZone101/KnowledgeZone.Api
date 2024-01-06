using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
