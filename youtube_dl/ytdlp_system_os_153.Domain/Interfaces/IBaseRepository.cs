using ytdlp_system_os_153.Domain.Entities;

namespace ytdlp_system_os_153.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T> GetAsync(Guid id, CancellationToken cancellationToken);
        Task<List<T>> GetAllAsync(CancellationToken cancellationToken);
    }
}
