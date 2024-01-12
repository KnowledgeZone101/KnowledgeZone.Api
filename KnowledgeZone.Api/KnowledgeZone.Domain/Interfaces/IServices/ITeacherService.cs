using KnowledgeZone.Domain.DTOs.Teacher;
using KnowledgeZone.Domain.Pagination;
using KnowledgeZone.Domain.ResourceParameters;

namespace KnowledgeZone.Domain.Interfaces.IServices
{
    public interface ITeacherService
    {
        PaginatedList<TeacherDto> GetTeacher(TeacherResourceParamentrs teacherParameters);
        TeacherDto? GetTeacherById(int id);
        TeacherDto CreateTeacher(TeacherForCreateDto teacherToCreate);
        void UpdateTeacher(TeacherForUpdateDto teacherToUpdate);
        void DeleteTeacher(int id);
    }
}
