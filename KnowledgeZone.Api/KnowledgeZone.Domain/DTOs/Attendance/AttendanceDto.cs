using KnowledgeZone.Domain.DTOs.Lesson;
using KnowledgeZone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeZone.Domain.DTOs.Attendance
{
    public record AttendanceDto(int AttendanceId, int StudentId, AttendanceType AttendanceType, Mark? Mark, int LessonId, LessonDto Lesson);
}
