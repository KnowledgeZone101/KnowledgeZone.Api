using KnowledgeZone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeZone.Domain.DTOs.Attendance
{
    public record AttendanceForCreateDto(int StudentId, AttendanceType AttendanceType, int LessonId);

}
