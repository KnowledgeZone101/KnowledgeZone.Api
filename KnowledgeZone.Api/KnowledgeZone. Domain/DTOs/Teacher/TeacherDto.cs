using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeZone.Domain.DTOs.Teacher
{
    public record TeacherDto(
        int TeacherId,
        string Name,
        string Email,
        int QualificationId,
        QualificationDto Qualification,
        ICollection<CourseDto> Courses);
}
