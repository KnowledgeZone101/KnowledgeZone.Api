using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeZone.Domain.DTOs.Room
{
    public record RoomDto(
        int RoomId,
        string Name,
        ICollection<LessonDto> Lessons);
}
