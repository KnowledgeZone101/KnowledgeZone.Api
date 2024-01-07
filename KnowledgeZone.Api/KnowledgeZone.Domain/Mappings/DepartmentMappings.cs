using AutoMapper;
using KnowledgeZone.Domain.DTOs.Department;
using KnowledgeZone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeZone.Domain.Mappings
{
    public class DepartmentMappings : Profile
    {
        public DepartmentMappings()
        {
            CreateMap<Department, DepartmentDto>();
            CreateMap<DepartmentDto, Department>();
            CreateMap<DepartmentForCreateDto, Department>();
            CreateMap<DepartmentForUpdateDto, Department>();
        }
    }
}
