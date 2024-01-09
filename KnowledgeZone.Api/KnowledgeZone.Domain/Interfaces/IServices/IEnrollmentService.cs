using KnowledgeZone.Domain.DTOs.Enrollment;
using KnowledgeZone.Domain.Pagination;
using KnowledgeZone.Domain.ResourceParameters;

namespace KnowledgeZone.Domain.Interfaces.IServices
{
    public interface IEnrollmentService
    {
        PaginatedList<EnrollmentDto> GetEnrollment(EnrollmentResourceParamentrs enrollmentParameters);
        EnrollmentDto? GetEnrollmentById(int id);
        EnrollmentDto CreateEnrollment(EnrollmentForCreateDto enrollmentToCreate);
        void UpdateEnrollment(EnrollmentForUpdateDto enrollmentToUpdate);
        void DeleteEnrollment(int id);
    }
}
