using KnowledgeZone.Domain.DTOs.Lesson;
using KnowledgeZone.Domain.Pagination;
using KnowledgeZone.Domain.ResourceParameters;

namespace KnowledgeZone.Domain.Interfaces.IServices
{
    public interface ILessonService
    {
        PaginatedList<LessonDto> GetLesson(LessonResourceParamentrs lessonParameters);
        LessonDto? GetLessonById(int id);
        LessonDto CreateLesson(LessonForCreateDto lessonToCreate);
        void UpdateLesson(LessonForUpdateDto lessonToUpdate);
        void DeleteLesson(int id);
    }
}
