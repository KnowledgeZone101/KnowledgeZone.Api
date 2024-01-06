

namespace KnowledgeZone.Domain.DTOs.Course
{
    public record CourseForUpdateDto(
        int CourseId,
        string Name,
        int TeacherId,
        int DepartmentId,
        int EnrollmentId,
        int CourseTypeId);
}
