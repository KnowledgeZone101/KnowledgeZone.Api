using KnowledgeZone.Domain.DTOs.Course;
using KnowledgeZone.Domain.Pagination;
using KnowledgeZone.Domain.ResourceParameters;

namespace KnowledgeZone.Domain.Interfaces.IServices
{
    public interface ICourseService
    {
        PaginatedList<CourseDto> GetCourse(CourseResourceParamentrs courseResourceParameters);
        CourseDto? GetCourseById(int id);
        CourseDto CreateCourse(CourseForCreateDto courseToCreate);
        void UpdateCourse(CourseForUpdateDto courseToUpdate);
        void DeleteCourse(int id);
    }
}
