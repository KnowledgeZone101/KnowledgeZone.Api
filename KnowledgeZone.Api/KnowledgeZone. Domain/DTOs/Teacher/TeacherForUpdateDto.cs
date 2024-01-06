using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeZone.Domain.DTOs.Teacher
{
    public record TeacherForUpdateDto(
        int TeacherId,
        string Name,
        string Email,
        int QualificationId);
}
