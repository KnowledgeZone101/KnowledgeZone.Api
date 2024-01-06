using KnowledgeZone.Domain.DTOs.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeZone.Domain.DTOs.Qualification
{
    public record QualificationDto(
        int QualificationId,
        string Name,
        ICollection<TeacherDto> Teachers);
}
