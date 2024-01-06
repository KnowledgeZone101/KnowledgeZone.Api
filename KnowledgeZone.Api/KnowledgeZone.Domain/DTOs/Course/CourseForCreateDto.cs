
namespace KnowledgeZone.Domain.DTOs.Course
{
    public record CourseForCreateDto(string Name, int TeacherId, int DepartmentId, int EnrollmentId, int CourseTypeId);
}
