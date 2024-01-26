using AutoMapper;
using KnowledgeZone.Domain.DTOs.Room;
using KnowledgeZone.Domain.Entities;

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
