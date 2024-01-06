

namespace KnowledgeZone.Domain.DTOs.Student
{
    public record StudentForUpdateDto(
        int StudentId,
        string Name,
        string Email,
        int EnrollmentId);
}
