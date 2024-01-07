using AutoMapper;
using KnowledgeZone.Domain.DTOs.Department;
using KnowledgeZone.Domain.DTOs.Room;
using KnowledgeZone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeZone.Domain.Mappings
{
    public class RoomMappings : Profile
    {
        public RoomMappings()
        {
            CreateMap<Room, RoomDto>();
            CreateMap<RoomDto, Room>();
            CreateMap<RoomForCreateDto, Room>();
            CreateMap<RoomForUpdateDto, Room>();
        }
    }
}
