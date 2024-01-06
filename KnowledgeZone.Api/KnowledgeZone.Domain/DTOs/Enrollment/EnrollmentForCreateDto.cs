

namespace KnowledgeZone.Domain.DTOs.Enrollment
{
    public record EnrollmentForCreateDto(string Name, ICollection<int> StudentIds, ICollection<int> CourseIds);
}
