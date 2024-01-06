using KnowledgeZone.Domain.Common;

namespace KnowledgeZone.Domain.Interfaces.Repository
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        Task<IEnumerable<T>> FindAllAsync();
        Task<T> FindByIdAsync(int id);
        Task<T> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
