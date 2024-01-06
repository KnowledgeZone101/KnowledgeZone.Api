using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeZone.Domain.DTOs.Enrollment
{
    public record EnrollmentForCreateDto(string Name, ICollection<int> StudentIds, ICollection<int> CourseIds);
}
