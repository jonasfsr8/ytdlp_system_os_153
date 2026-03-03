using ytdlp_system_os_153.Domain.Interfaces;
using ytdlp_system_os_153.Infrastructure.Context;

namespace ytdlp_system_os_153.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task Commit(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
