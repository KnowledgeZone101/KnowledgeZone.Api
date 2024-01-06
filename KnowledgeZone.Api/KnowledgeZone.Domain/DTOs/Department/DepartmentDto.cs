﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeZone.Domain.DTOs.Department
{
    public record DepartmentDto(
        int DepartmentId,
        string Name,
        ICollection<CourseDto> Courses);
}
