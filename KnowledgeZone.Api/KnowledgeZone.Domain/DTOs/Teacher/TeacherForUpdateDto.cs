

namespace KnowledgeZone.Domain.DTOs.Teacher
{
    public record TeacherForUpdateDto(
        int TeacherId,
        string Name,
        string Email,
        int QualificationId);
}
