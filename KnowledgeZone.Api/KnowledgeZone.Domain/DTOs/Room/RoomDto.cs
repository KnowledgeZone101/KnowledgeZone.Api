using KnowledgeZone.Domain.DTOs.Lesson;

namespace KnowledgeZone.Domain.DTOs.Room
{
    public record RoomDto(
        int RoomId,
        string Name,
        ICollection<LessonDto> Lessons);
}
