using KnowledgeZone.Domain.DTOs.Teacher;

namespace KnowledgeZone.Domain.DTOs.Qualification
{
    public record QualificationDto(
        int QualificationId,
        string Name,
        ICollection<TeacherDto> Teachers);
}
