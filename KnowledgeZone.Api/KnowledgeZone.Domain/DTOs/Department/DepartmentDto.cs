using KnowledgeZone.Domain.DTOs.Course;

namespace KnowledgeZone.Domain.DTOs.Department
{
    public record DepartmentDto(
        int DepartmentId,
        string Name,
        ICollection<CourseDto> Courses);
}
