using KnowledgeZone.Domain.DTOs.Course;
using KnowledgeZone.Domain.DTOs.Student;


namespace KnowledgeZone.Domain.DTOs.Enrollment
{
    public record EnrollmentDto(
        int EnrollmentId,
        string Name,
        ICollection<StudentDto> Students,
        ICollection<CourseDto> Courses);
}
