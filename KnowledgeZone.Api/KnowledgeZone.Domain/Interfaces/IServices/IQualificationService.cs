using KnowledgeZone.Domain.DTOs.Qualification;
using KnowledgeZone.Domain.Pagination;
using KnowledgeZone.Domain.ResourceParameters;


namespace KnowledgeZone.Domain.Interfaces.IServices
{
    public interface IQualificationService
    {
        PaginatedList<QualificationDto> GetQualification(QualificationResourceParamentrs qualificationParameters);
        QualificationDto? GetQualificationById(int id);
        QualificationDto CreateQualification(QualificationForCreateDto qualificationToCreate);
        void UpdateQualification(QualificationForUpdateDto qualificationToUpdate);
        void DeleteQualification(int id);
    }
}
