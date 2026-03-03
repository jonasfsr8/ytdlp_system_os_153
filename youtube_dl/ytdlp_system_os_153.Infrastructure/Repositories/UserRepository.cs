using Microsoft.EntityFrameworkCore;
using ytdlp_system_os_153.Domain.Entities;
using ytdlp_system_os_153.Domain.Interfaces;
using ytdlp_system_os_153.Infrastructure.Context;

namespace ytdlp_system_os_153.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context) : base(context) { }

        public async Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
        }
    }
}
