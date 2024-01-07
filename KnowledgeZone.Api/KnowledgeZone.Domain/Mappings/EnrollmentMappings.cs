using AutoMapper;
using KnowledgeZone.Domain.DTOs.Department;
using KnowledgeZone.Domain.DTOs.Enrollment;
using KnowledgeZone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeZone.Domain.Mappings
{
    public class EnrollmentMappings : Profile
    {
        public EnrollmentMappings()
        { 
            CreateMap<Enrollment, EnrollmentDto>();
            CreateMap<EnrollmentDto, Enrollment>();
            CreateMap<EnrollmentForCreateDto, Enrollment>();
            CreateMap<EnrollmentForUpdateDto, Enrollment>();
        }
    }
}
