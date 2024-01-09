using KnowledgeZone.Domain.DTOs.Room;
using KnowledgeZone.Domain.Pagination;
using KnowledgeZone.Domain.ResourceParameters;

namespace KnowledgeZone.Domain.Interfaces.IServices
{
    public interface IRoomService
    {
        PaginatedList<RoomDto> GetRoom(RoomResourceParamentrs roomParameters);
        RoomDto? GetRoomById(int id);
        RoomDto CreateRoom(RoomForCreateDto roomToCreate);
        void UpdateRoom(RoomForUpdateDto roomToUpdate);
        void DeleteRoom(int id);
    }
}
