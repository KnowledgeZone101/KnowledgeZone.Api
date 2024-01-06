

namespace KnowledgeZone.Domain.DTOs.Teacher
{
    public record TeacherForCreateDto(
        string Name,
        string Email,
        int QualificationId);
}
