using KnowledgeZone.Domain.DTOs.Student;
using KnowledgeZone.Domain.Pagination;
using KnowledgeZone.Domain.ResourceParameters;

namespace KnowledgeZone.Domain.Interfaces.IServices
{
    public interface IStudentService
    {
        PaginatedList<StudentDto> GetStudent(StudentResourceParamentrs studentParameters);
        StudentDto? GetStudentById(int id);
        StudentDto CreateStudent(StudentForCreateDto studentToCreate);
        void UpdateStudent(StudentForUpdateDto studentToUpdate);
        void DeleteStudent(int id);
    }
}
