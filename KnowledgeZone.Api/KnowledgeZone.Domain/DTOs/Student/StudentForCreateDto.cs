using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeZone.Domain.DTOs.Student
{
    public record StudentForCreateDto(
        string Name,
        string Email,
        int EnrollmentId);
}
