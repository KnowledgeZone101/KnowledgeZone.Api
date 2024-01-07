using AutoMapper;
using KnowledgeZone.Domain.DTOs.CourseType;
using KnowledgeZone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeZone.Domain.Mappings
{
    public class CourseTypeMappings : Profile
    {
        public CourseTypeMappings()
        {
            CreateMap<CourseType, CourseTypeDto>();
            CreateMap<CourseTypeDto, CourseType>();
            CreateMap<CourseTypeForCreateDto, CourseType>();
            CreateMap<CourseTypeForUpdateDto, CourseType>();    
        }
    }
}
