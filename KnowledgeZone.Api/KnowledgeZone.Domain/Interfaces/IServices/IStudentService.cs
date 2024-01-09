using KnowledgeZone.Domain.DTOs.Student;
using KnowledgeZone.Domain.Pagination;
using KnowledgeZone.Domain.ResourceParameters;

namespace KnowledgeZone.Domain.Interfaces.IServices
{
    public interface IStudentService
    {
        PaginatedList<StudentDto> GetStudent(StudentResourceParamentrs qualificationParameters);
        StudentDto? GetStudentById(int id);
        StudentDto CreateStudent(StudentForCreateDto qualificationToCreate);
        void UpdateStudent(StudentForUpdateDto qualificationToUpdate);
        void DeleteStudent(int id);
    }
}
