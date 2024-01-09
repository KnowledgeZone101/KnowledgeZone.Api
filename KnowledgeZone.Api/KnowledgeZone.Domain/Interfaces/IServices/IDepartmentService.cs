using KnowledgeZone.Domain.DTOs.Department;
using KnowledgeZone.Domain.Pagination;
using KnowledgeZone.Domain.ResourceParameters;

namespace KnowledgeZone.Domain.Interfaces.IServices
{
    public interface IDepartmentService
    {
        PaginatedList<DepartmentDto> GetDepartment(DepartmentResourceParamentrs departmentParameters);
        DepartmentDto? GetDepartmentById(int id);
        DepartmentDto CreateDepartment(DepartmentForCreateDto departmentToCreate);
        void UpdateDepartment(DepartmentForUpdateDto departmentToUpdate);
        void DeleteDepartment(int id);
    }
}
