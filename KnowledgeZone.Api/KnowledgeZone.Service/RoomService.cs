using AutoMapper;
using KnowledgeZone.Domain.DTOs.Room;
using KnowledgeZone.Domain.Entities;
using KnowledgeZone.Domain.Interfaces.IServices;
using KnowledgeZone.Domain.Pagination;
using KnowledgeZone.Domain.ResourceParameters;
using KnowledgeZone.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeZone.Service
{
    public class RoomService : IRoomService
    {
        private readonly IMapper _mapper;
        private readonly KnowledgeZoneDbContext _context;

        public RoomService(IMapper mapper, KnowledgeZoneDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public PaginatedList<RoomDto> GetRoom(RoomResourceParamentrs roomParameters)
        {
            var query = _context.Rooms.AsQueryable();

            if (!string.IsNullOrEmpty(roomParameters.SearchString))
            {
                query = query.Where(r => r.Name.Contains(roomParameters.SearchString));
            }

            if(roomParameters.OrderBy is not null)
            {
                switch (roomParameters.OrderBy)
                {
                    case "name":
                        query = query.OrderBy(r => r.Name);
                        break;
                    case "name_desc":
                        query = query.OrderByDescending(r => r.Name);
                        break;
                }
            }

            var rooms = query.ToPaginatedList(roomParameters.PageSize, roomParameters.PageNumber);
            var roomsDto = _mapper.Map<PaginatedList<RoomDto>>(rooms);

            return new PaginatedList<RoomDto>(roomsDto, rooms.TotalCount, rooms.CurrentPage, rooms.PageSize);
        }

        public RoomDto? GetRoomById(int id)
        {
            var room = _context.Rooms.FirstOrDefault(r => r.Id == id);
            var roomDto = _mapper.Map<RoomDto>(room);

            return roomDto;
        }
        public RoomDto CreateRoom(RoomForCreateDto roomToCreate)
        {
            var room = _mapper.Map<Room>(roomToCreate);

            _context.Rooms.Add(room);
            _context.SaveChanges();

            var roomDto = _mapper.Map<RoomDto>(room);

            return roomDto;
        }
        public void UpdateRoom(RoomForUpdateDto roomToUpdate)
        {
            var room = _mapper.Map<Room>(roomToUpdate);

            _context.Rooms.Update(room);
            _context.SaveChanges();
        }

        public void DeleteRoom(int id)
        {
            var room = _context.Rooms.FirstOrDefault(r => r.Id == id);

            if (room is not null)
            {
                _context.Rooms.Remove(room);
            }
            _context.SaveChanges();
        }
    }
}
