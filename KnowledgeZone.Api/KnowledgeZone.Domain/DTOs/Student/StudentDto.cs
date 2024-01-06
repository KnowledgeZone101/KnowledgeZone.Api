using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeZone.Domain.DTOs.Student
{
    public record StudentDto(
        int StudentId,
        string Name,
        string Email,
        int EnrollmentId,
        EnrollmentDto Enrollment);
}
