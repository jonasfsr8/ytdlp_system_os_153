using Microsoft.EntityFrameworkCore;
using ytdlp_system_os_153.Domain.Entities;
using ytdlp_system_os_153.Domain.Interfaces;
using ytdlp_system_os_153.Infrastructure.Context;

namespace ytdlp_system_os_153.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            entity.DateCreated = DateTimeOffset.UtcNow;
            _context.Add(entity);
        }

        public void Update(T entity)
        {
            entity.DateUpdated = DateTimeOffset.UtcNow;
            _context.Update(entity);
        }

        public void Delete(T entity)
        {
            entity.DateDeleted = DateTimeOffset.UtcNow;
            _context.Update(entity);
        }

        public async Task<T> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
        }

        public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Set<T>().ToListAsync(cancellationToken);
        }
    }
}
