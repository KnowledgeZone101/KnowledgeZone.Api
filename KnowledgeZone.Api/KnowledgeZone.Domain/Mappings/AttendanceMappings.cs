using AutoMapper;
using KnowledgeZone.Domain.DTOs.Attendance;
using KnowledgeZone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeZone.Domain.Mappings
{
    public class AttendanceMappings : Profile 
    {
        public AttendanceMappings()
        {
            CreateMap<Attendance, AttendanceDto>();
            CreateMap<AttendanceDto, Attendance>();
            CreateMap<AttendanceForCreateDto, Attendance>();
            CreateMap<AttendanceForUpdateDto, Attendance>();
        }
    }
}
