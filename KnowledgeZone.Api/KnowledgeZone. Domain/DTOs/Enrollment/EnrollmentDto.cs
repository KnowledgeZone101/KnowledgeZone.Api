using KnowledgeZone.Domain.DTOs.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeZone.Domain.DTOs.Enrollment
{
    public record EnrollmentDto(
        int EnrollmentId,
        string Name,
        ICollection<StudentDto> Students,
        ICollection<CourseDto> Courses);
}
