using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeZone.Domain.DTOs.Teacher
{
    public record TeacherForCreateDto(
        string Name,
        string Email,
        int QualificationId);
}
