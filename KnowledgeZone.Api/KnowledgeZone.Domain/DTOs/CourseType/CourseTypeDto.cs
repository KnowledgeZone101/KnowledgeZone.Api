using KnowledgeZone.Domain.DTOs.Course;

namespace KnowledgeZone.Domain.DTOs.CourseType
{
    public record CourseTypeDto(int Id, string Name, ICollection<CourseDto> Courses);
}
