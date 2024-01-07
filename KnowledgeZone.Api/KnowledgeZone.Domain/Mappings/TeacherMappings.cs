using AutoMapper;
using KnowledgeZone.Domain.DTOs.Department;
using KnowledgeZone.Domain.DTOs.Teacher;
using KnowledgeZone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeZone.Domain.Mappings
{
    public class TeacherMappings : Profile
    {
        public TeacherMappings()
        {
            CreateMap<Teacher, TeacherDto>();
            CreateMap<TeacherDto, Teacher>();
            CreateMap<TeacherForCreateDto, Teacher>();
            CreateMap<TeacherForUpdateDto, Teacher>();
        }
    }
}
