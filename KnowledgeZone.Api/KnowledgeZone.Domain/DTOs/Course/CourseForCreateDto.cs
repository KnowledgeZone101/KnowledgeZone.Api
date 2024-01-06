using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeZone.Domain.DTOs.Course
{
    public record CourseForCreateDto(string Name, int TeacherId, int DepartmentId, int EnrollmentId, int CourseTypeId);
}
