using KnowledgeZone.Domain.DTOs.Enrollment;

namespace KnowledgeZone.Domain.DTOs.Student
{
    public record StudentDto(
        int StudentId,
        string Name,
        string Email,
        int EnrollmentId
        //EnrollmentDto Enrollment
    );
}
