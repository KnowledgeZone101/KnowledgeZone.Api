

namespace KnowledgeZone.Domain.DTOs.Student
{
    public record StudentForCreateDto(
        string Name,
        string Email,
        int EnrollmentId);
}
