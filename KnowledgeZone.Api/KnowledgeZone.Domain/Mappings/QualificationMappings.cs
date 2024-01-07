using AutoMapper;
using KnowledgeZone.Domain.DTOs.Department;
using KnowledgeZone.Domain.DTOs.Qualification;
using KnowledgeZone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeZone.Domain.Mappings
{
    public class QualificationMappings : Profile
    {
        public QualificationMappings()
        {
            CreateMap<Qualification, QualificationDto>();
            CreateMap<QualificationDto, Qualification>();
            CreateMap<QualificationForCreateDto, Qualification>();
            CreateMap<QualificationForUpdateDto, Qualification>();
        }
    }
}
