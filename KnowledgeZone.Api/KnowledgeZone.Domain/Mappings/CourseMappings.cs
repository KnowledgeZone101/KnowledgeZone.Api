using AutoMapper;
using KnowledgeZone.Domain.DTOs.Course;
using KnowledgeZone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeZone.Domain.Mappings
{
    public class CourseMappings : Profile
    {
        public CourseMappings()
        {
            CreateMap<Course, CourseDto>();
            CreateMap<CourseDto, Course>();
            CreateMap<CourseForCreateDto,Course>();
            CreateMap<CourseForUpdateDto,Course>();
        }
    }
}
