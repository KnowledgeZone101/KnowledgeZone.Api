using AutoMapper;
using KnowledgeZone.Domain.DTOs.CourseType;
using KnowledgeZone.Domain.Entities;

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
