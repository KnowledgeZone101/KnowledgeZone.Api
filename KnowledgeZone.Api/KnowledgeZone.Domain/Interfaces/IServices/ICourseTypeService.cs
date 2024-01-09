using KnowledgeZone.Domain.DTOs.CourseType;
using KnowledgeZone.Domain.Pagination;
using KnowledgeZone.Domain.ResourceParameters;

namespace KnowledgeZone.Domain.Interfaces.IServices
{
    public interface ICourseTypeService
    {
        PaginatedList<CourseTypeDto> GetCourseType(CourseTypeResourceParamentrs courseTypeResourceParameters);
        CourseTypeDto? GetCourseTypeById(int id);
        CourseTypeDto CreateCourseType(CourseTypeForCreateDto courseTypeToCreate);
        void UpdateCourseType(CourseTypeForUpdateDto courseTypeToUpdate);
        void DeleteCourseType(int id);
    }
}
