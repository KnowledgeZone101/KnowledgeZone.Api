using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeZone.Domain.DTOs.CourseType
{
    public record CourseTypeDto(int CourseTypeId, string Name, ICollection<CourseDto> Courses);
}
