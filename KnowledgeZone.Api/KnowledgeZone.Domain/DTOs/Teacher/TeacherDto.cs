using KnowledgeZone.Domain.DTOs.Course;
using KnowledgeZone.Domain.DTOs.Qualification;

namespace KnowledgeZone.Domain.DTOs.Teacher
{
    public record TeacherDto(
        int TeacherId,
        string Name,
        string Email,
        int QualificationId,
        QualificationDto Qualification,
        ICollection<CourseDto> Courses);
}
