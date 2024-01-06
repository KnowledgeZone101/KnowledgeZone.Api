using KnowledgeZone.Domain.DTOs.CourseType;
using KnowledgeZone.Domain.DTOs.Department;
using KnowledgeZone.Domain.DTOs.Enrollment;
using KnowledgeZone.Domain.DTOs.Teacher;

namespace KnowledgeZone.Domain.DTOs.Course
{
    public record CourseDto(
        int CourseId,
        string Name,
        int TeacherId,
        TeacherDto Teacher,
        int DepartmentId,
        DepartmentDto Department,
        int EnrollmentId, EnrollmentDto
        Enrollment,
        int CourseTypeId,
        CourseTypeDto CourseType);
}
